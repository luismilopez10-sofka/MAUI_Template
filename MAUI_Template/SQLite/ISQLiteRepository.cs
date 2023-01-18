using SQLite;

namespace MAUI_Template.SQLite;

public interface ISQLiteRepository
{
    Task<CreateTableResult> CreateTable<T>() where T : new();
    Task<List<T>> GetAll<T>() where T : new();
    Task<T> Find<T>(object primaryKey) where T : new();
    Task<List<T>> Filter<T>(string table, string condition) where T : new();
    Task<int> Save<T>(T item) where T : new();
    Task<int> Update<T>(T item) where T : new();
    Task<int> UpdateList<T>(List<T> item) where T : new();
    Task<int> Delete<T>(T item) where T : new();
    Task<int> DeleteAll<T>() where T : new();
    void DeleteList<T>(List<T> itemsToDelete) where T : new();
    Task<int> DropTable<T>() where T : new();
}
