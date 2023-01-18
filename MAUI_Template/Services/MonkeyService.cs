using System.Net.Http.Json;

namespace MAUI_Template.Services;

public class MonkeyService
{
    List<MdlMonkey> monkeyList;
    readonly HttpClient httpClient;
    readonly string baseUrl = "https://montemagno.com/";

    public MonkeyService()
    {
        httpClient = new();
    }


    public async Task<List<MdlMonkey>> GetMonkeys()
    {
        var url = "monkeys.json";
        var uri = new Uri(baseUrl + url);

        if (monkeyList?.Count > 0)
            return monkeyList;

        var response = await httpClient.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            monkeyList = await response.Content.ReadFromJsonAsync<List<MdlMonkey>>();
        }

        return monkeyList;
    }
}