using SQLite;

namespace MAUI_Template.Model;

[Table("users")]
public class MdlUser
{
    [PrimaryKey]
    public string Username { get; set; }
    [NotNull]
    public string Password { get; set; }
    public bool Logged { get; set; }

    public MdlUser()
    {
        Logged = false;
    }

    public MdlUser(string username, string password)
    {
        Username = username;
        Password = password;
        Logged = false;
    }
}