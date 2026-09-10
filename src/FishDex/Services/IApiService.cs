using FishDex.Models;

namespace FishDex.Services
{
    public interface IApiService
    {
        public Task<List<Fish>> GetFishAsync();

        public List<Fish> DebugFishList();

    }
}