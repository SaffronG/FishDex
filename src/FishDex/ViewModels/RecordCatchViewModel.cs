using FishDex.Models;
using System.ComponentModel;
using System.Text.Json;

namespace FishDex.ViewModels
{
    public partial class RecordCatchViewModel() : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string FishNameEntry { get; set; } = "Rainbow Trout";
        public decimal FishWeightEntry { get; set; } = 3.13m;
        public decimal FishLengthEntry { get; set; } = 5.4m;
        public string FishImageSource 
        { 
            get => field; 
            set
            {
                if (field != value)
                {
                    field = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FishImageSource)));
                }
            }
        } = "fish_silhouette.png";
        Page? NavHandle { get => Application.Current?.MainPage; }
        public Command SaveButtonClickedCommand => field ??= new Command(async () =>
        {
            if (NavHandle != null)
            {
                await NavHandle.DisplayAlertAsync("Catch Recorded", "Your catch has been recorded successfully!", "OK");
                await AddImageToLocalStorage(File.OpenRead(FishImageSource), FishNameEntry);
                await NavHandle.Navigation.PopModalAsync();
            }
        });
        public Command CancelButtonClickedCommand => field ??= new Command(async () =>
        {
            if (NavHandle != null)
            {
                await NavHandle.Navigation.PopModalAsync();
            } 
        });
        public Command PickPhotosAsyncCommand => field ??= new Command(async () =>
        {
            List<FileResult>? photoList = await MediaPicker.Default.PickPhotosAsync();
            if (photoList.Count > 0 && NavHandle != null)
                try
                {
                    FishImageSource = Path.Combine(FileSystem.CacheDirectory, photoList?.FirstOrDefault()?.FileName ?? "temp.jpg");
                } catch (Exception ex)
                {
                    await NavHandle.DisplayAlertAsync("Could not open photo", ex.Message, "OK");
                }
            else if (NavHandle != null)
            {
                await NavHandle.DisplayAlertAsync("No photo selected", "You did not select a photo.", "OK");
            }
        });
        public Command TakePhotoAsyncCommand => field ??= new Command(async () =>
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                if (photo != null)
                {
                    // Save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream stream = await photo.OpenReadAsync(); // FileStream from photo
                    using FileStream newStream = File.OpenWrite(localFilePath); // FileStream to write to local file
                    FishImageSource = localFilePath; // update the image source to the new local file path
                    await stream.CopyToAsync(newStream);
                }
                else // photo is null, user canceled the camera capture
                {
                    await NavHandle?.DisplayAlertAsync("No Photo taken", "You did not take a photo", "OK");
                }
            }
            else // Camera capture is not supported on this device
            {
                await NavHandle?.DisplayAlertAsync("Camera not supported", "Your device does not support camera capture.", "OK");
            }
        });

        public async Task AddImageToLocalStorage(Stream imageStream, string FishAssociation)
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

        public async Task<List<StoredFishPic>> LoadLibraryAsync()
        {
            string libPath = Path.Combine(FileSystem.AppDataDirectory, "persistance.json");

            if (!File.Exists(libPath))
            {
                return [];
            }

            string jsonString = await File.ReadAllTextAsync(libPath);
            return JsonSerializer.Deserialize<List<StoredFishPic>>(jsonString) ?? [];
        }
    }
}
