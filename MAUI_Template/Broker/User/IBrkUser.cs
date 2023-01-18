namespace MAUI_Template.Broker.User;

public interface IBrkUser
{
    Task<string> Login(MdlUser objMdlUser);
    Task<string> CreateUser(MdlUser objMdlUser);
}