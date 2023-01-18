using SQLite;

namespace MAUI_Template.SQLite;

public sealed class SQLiteRepository : ISQLiteRepository
{
    private readonly SQLiteAsyncConnection _database;
    private const string _databaseName = "database.db";

    public SQLiteRepository()
    {
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _databaseName);
        _database = new SQLiteAsyncConnection(dbPath);
    }

    /// <summary>
    ///     Executes a "create table if not exists" on the database. It also creates any
    ///     specified indexes on the columns of the table. It uses a schema automatically
    ///     generated from the specified type. You can later access this schema by calling
    ///     GetMapping.
    /// </summary>
    /// <typeparam name="T">
    ///     T:
    ///         The type of object.
    /// </typeparam>
    public async Task<CreateTableResult> CreateTable<T>() where T : new()
    {
        return await _database.CreateTableAsync<T>();
    }

    /// <summary>
    ///     Returns a queryable interface to the table represented by the given type.
    /// </summary>
    /// <typeparam name="T">
    ///     T:
    ///         The type of object.
    /// </typeparam>
    /// <returns>
    ///     A queryable object that is able to translate Where, OrderBy, and Take queries
    ///     into native SQL.
    /// </returns>
    public async Task<List<T>> GetAll<T>() where T : new()
    {
        await CreateTable<T>();
        return await _database.Table<T>().ToListAsync();
    }

    /// <summary>
    ///     Attempts to retrieve an object with the given primary key from the table associated
    ///     with the specified type. Use of this method requires that the given type have
    ///     a designated PrimaryKey (using the PrimaryKeyAttribute).
    /// </summary>
    /// <typeparam name="T">
    ///     T:
    ///         The type of object.
    /// </typeparam>
    /// <param name="primaryKey">
    ///     primaryKey:
    ///         The primary key.
    /// </param>
    /// <returns>
    ///     The object with the given primary key or null if the object is not found.
    /// </returns>
    public async Task<T> Find<T>(object primaryKey) where T : new()
    {
        await CreateTable<T>();
        return await _database.FindAsync<T>(primaryKey);
    }

    /// <summary>
    /// Gets the filtered data from the table with the given condition
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="table"></param>
    /// <param name="condition"></param>
    /// <returns></returns>
    public async Task<List<T>> Filter<T>(string table, string condition) where T : new()
    {
        await CreateTable<T>();

        var data = new List<T>();
        try
        {
            data = await _database.QueryAsync<T>($"SELECT * FROM {table} WHERE {condition};");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return data;
    }

    /// <summary>
    ///     create the table of the given type and inserts the given object (and updates its auto incremented primary key if it
    ///     has one). The return value is the number of rows added to the table.
    /// </summary>
    /// <typeparam name="T">
    ///     T:
    ///         The type of object.
    /// </typeparam>
    /// <param name="item">
    ///     obj:
    ///         The object to insert.
    /// </param>
    /// <returns>
    ///     The number of rows added to the table.
    /// </returns>     
    public async Task<int> Save<T>(T item) where T : new()
    {
        await CreateTable<T>();
        try
        {
            return await _database.InsertAsync(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

        }
        return 0;
    }

    /// <summary>
    ///     Updates all of the columns of a table using the specified object except for its
    ///     primary key. The object is required to have a primary key.
    /// </summary>
    /// <param name="item">
    ///     obj:
    ///         The object to update. It must have a primary key designated using the PrimaryKeyAttribute.
    /// </param>
    /// <returns>
    ///     The number of rows updated.
    /// </returns>
    public async Task<int> Update<T>(T item) where T : new()
    {
        await CreateTable<T>();
        return await _database.UpdateAsync(item);
    }

    /// <summary>
    ///     Updates all of the columns of a table using the specified object except for its
    ///     primary key. The object is required to have a primary key.
    /// </summary>
    /// <param name="item">
    ///     obj:
    ///         The object to update. It must have a primary key designated using the PrimaryKeyAttribute.
    /// </param>
    /// <returns>
    ///     The number of rows updated.
    /// </returns>
    public async Task<int> UpdateList<T>(List<T> item) where T : new()
    {
        await CreateTable<T>();
        return await _database.UpdateAllAsync(item);
    }

    /// <summary>
    ///     Deletes the given object from the database using its primary key.
    /// </summary>
    /// <param name="item">
    ///     objectToDelete:
    ///         The object to delete. It must have a primary key designated using the PrimaryKeyAttribute.
    /// </param>
    /// <returns>
    ///     The number of rows deleted.
    /// </returns>
    public async Task<int> Delete<T>(T item) where T : new()
    {
        await CreateTable<T>();
        return await _database.DeleteAsync(item);
    }

    /// <summary>
    ///     Deletes all the objects from the specified table. WARNING WARNING: Let me repeat.
    ///     It deletes ALL the objects from the specified table. Do you really want to do
    ///     that?
    /// </summary>
    /// <typeparam name="T">
    ///     T:
    ///         The type of objects to delete.
    /// </typeparam>
    /// <returns>
    ///     The number of objects deleted.
    /// </returns>
    public async Task<int> DeleteAll<T>() where T : new()
    {
        await CreateTable<T>();
        return await _database.DeleteAllAsync<T>();
    }

    /// <summary>
    ///     Delete a list of objects gieven to the mehod
    /// </summary>
    /// <param name="itemsToDelete">
    ///     obj:
    ///        the list of objects to delete
    /// </param>
    public void DeleteList<T>(List<T> itemsToDelete) where T : new()
    {
        itemsToDelete.ForEach(async item =>
        {
            try
            {
                await _database.DeleteAsync(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        });
    }

    /// <summary>
    ///     Executes a "drop table" on the database. This is non-recoverable.
    /// </summary>
    /// <typeparam name="T">
    ///     T:
    ///         The type of object.
    /// </typeparam>
    /// <returns></returns>
    public async Task<int> DropTable<T>() where T : new()
    {
        await CreateTable<T>();
        return await _database.DropTableAsync<T>();
    }
}

