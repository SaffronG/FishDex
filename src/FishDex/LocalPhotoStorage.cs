using FishDex.Models;
using System.Text.Json;

namespace FishDex;

/// <summary>
/// This class provides methods for storing and retrieving images of fish catches in local storage. It allows adding images to local storage, loading the library of stored images, and persisting the library to a JSON file.
/// </summary>

public class LocalPhotoStorage
{
    /// <summary>
    /// Adds an image to local storage and updates the library of stored images. The image is saved with a filename based on the associated fish name, and the library is persisted to a JSON file.
    /// </summary>
    /// <param name="imageStream"></param>
    /// <param name="FishAssociation"></param>
    /// <returns></returns>
    public static async Task AddImageToLocalStorage(Stream imageStream, string FishAssociation)
    {
        string setFilename = $"{FishAssociation}.jpg";
        string imagePath = Path.Combine(FileSystem.AppDataDirectory, setFilename);
        using FileStream localStream = File.Create(imagePath); // sets local data location for image
        await imageStream.CopyToAsync(localStream); // saves said data

        List<StoredFishPic> localLibrary = await LoadLibraryAsync();
        localLibrary.Add(new StoredFishPic(setFilename, FishAssociation));

        string libraryPersistPath = Path.Combine(FileSystem.AppDataDirectory, "persistence.json");
        string libAsJson = JsonSerializer.Serialize(localLibrary);
        await File.WriteAllTextAsync(libraryPersistPath, libAsJson);
    }

    /// <summary>
    /// Loads the library of stored images from a JSON file in local storage. If the file does not exist, an empty list is returned. The method deserializes the JSON data into a list of StoredFishPic objects.
    /// </summary>
    /// <returns></returns>
    public static async Task<List<StoredFishPic>> LoadLibraryAsync()
    {
        string libPath = Path.Combine(FileSystem.AppDataDirectory, "persistence.json");

        if (!File.Exists(libPath))
        {
            return [];
        }

        string jsonString = await File.ReadAllTextAsync(libPath);
        return JsonSerializer.Deserialize<List<StoredFishPic>>(jsonString) ?? [];
    }

}
