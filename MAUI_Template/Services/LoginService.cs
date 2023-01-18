using System.Net.Http.Json;

namespace MAUI_Template.Services;

public class LoginService
{
    MdlUser user = new();
    readonly HttpClient httpClient;
    readonly string baseUrl = "";

    public LoginService()
    {
        httpClient = new();
    }


    public async Task<MdlUser> UserLogin()
    {
        var url = "";
        var uri = new Uri(baseUrl + url);
        var response = await httpClient.GetAsync(uri);

        if (response.IsSuccessStatusCode)
        {
            user = await response.Content.ReadFromJsonAsync<MdlUser>();
        }

        return user;
    }
}
