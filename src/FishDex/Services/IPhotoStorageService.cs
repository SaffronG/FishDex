using FishDex.Models;

namespace FishDex.Services;

public interface IPhotoStorageService
{
    public Task AddImageToLocalStorage(Stream imageStream, string FishAssociation);
    public Task<List<StoredFishPic>> LoadLibraryAsync();
}
