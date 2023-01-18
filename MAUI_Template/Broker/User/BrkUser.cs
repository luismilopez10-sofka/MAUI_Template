using System.Collections;

namespace MAUI_Template.Broker.User;

public class BrkUser : IBrkUser
{
    private readonly ISQLiteRepository _sqliteRepository = new SQLiteRepository();
    public static readonly IDictionary responses = new Dictionary<int, string>()
    {
        {200, "Logged"},
        {201, "User created"},
        {303, "User already exists"},
        {404, "User not found"},
        {406, "Incorrect password"}
    };

    public async Task<string> Login(MdlUser objMdlUser)
    {
        MdlUser dbUser = await _sqliteRepository.Find<MdlUser>(objMdlUser.Username);

        if (dbUser == null)
            return responses[404]!.ToString()!;

        if (!dbUser.Password.Equals(objMdlUser.Password))
            return responses[406]!.ToString()!;

        return responses[200]!.ToString()!;
    }

    public async Task<string> CreateUser(MdlUser objMdlUser)
    {
        int result = await _sqliteRepository.Save(objMdlUser);

        if (result == 0)
        {
            return responses[303]!.ToString()!;
        }

        return responses[201]!.ToString()!;
    }
}
