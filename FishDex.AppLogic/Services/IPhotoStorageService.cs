namespace FishDex.AppLogic.Services;

public interface IPhotoStorageService
{
    public Task AddImageToLocalStorage(Stream imageStream, string FishAssociation);
    public Task<List<StoredFishPic>> LoadLibraryAsync();
    public Task<string?> GetPhotoFromUser(string association);
    public Task<string?> TakePhotoAsync();
}