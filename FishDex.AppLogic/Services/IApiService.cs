namespace FishDex.AppLogic.Services;
public interface IApiService
{
    public Task<List<Fish>> GetFishAsync();
    public Task<List<Fish>> GetFishByName(string name);
    public Task<List<Fish>> GetFishByIndex(int index);
    public List<Fish> DebugFishList();
}