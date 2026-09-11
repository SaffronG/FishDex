using System.Net.Http.Json;

namespace FishDex.Services;

public class ApiService() : IApiService
{
    public readonly List<Fish> DebugFishList = [new Fish("Bass", 5.5m, 2.0m), new Fish("Trout", 3.2m, 1.5m), new Fish("Salmon", 8.1m, 3.0m), new Fish("Catfish", 12.0m, 5.0m), new Fish("Pike", 6.8m, 2.5m), new Fish("Burbot", 4.5m, 1.8m), new Fish("Rainbow Trout", 7.3m, 2.2m)];
    private readonly HttpClient Client = new()
    {
        BaseAddress = new Uri("https://fishdexapi-dsaabcd0arh3dxhv.westus3-01.azurewebsites.net"),
        Timeout = TimeSpan.FromSeconds(30),
    };

    public async Task<List<Fish>> GetFishAsync()
    {
        try
        {
            var response = await Client.GetAsync("api/fish");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<Fish>>() ?? DebugFishList;
            else
                return DebugFishList;
        }
        catch (Exception ex)
        {
            return new List<Fish>();
        }
    }

    public async Task<List<Fish>> GetFishByIndex(int index)
    {
        try
        {
            var response = await Client.GetAsync($"api/fish/byindex?index={index}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<Fish>>() ?? DebugFishList;
            else
                return DebugFishList;
        }
        catch (Exception ex)
        {
            return new List<Fish>();
        }
    }

    public async Task<List<Fish>> GetFishByName(string name)
    {
        try
        {
            var response = await Client.GetAsync($"api/fish/byname?search={name}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<Fish>>() ?? DebugFishList;
            else
                return DebugFishList;
        }
        catch (Exception ex)
        {
            return new List<Fish>();
        }
    }

    List<Fish> IApiService.DebugFishList() => DebugFishList;
}

