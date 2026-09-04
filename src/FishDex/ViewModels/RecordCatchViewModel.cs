using System.ComponentModel;
using Microsoft.Maui.Media;

namespace FishDex.ViewModels
{
    public partial class RecordCatchViewModel() : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public Command SaveButtonClickedCommand => field ??= new Command(async () =>
        {
            var nav = Application.Current?.MainPage;
            if (nav != null)
            {
                await nav.DisplayAlertAsync("Catch Recorded", "Your catch has been recorded successfully!", "OK");
                await nav.Navigation.PopModalAsync();
            }
        });
        public Command CancelButtonClickedCommand => field ??= new Command(async () =>
        {
            var nav = Application.Current?.MainPage;
            if (nav != null)
            {
                await nav.Navigation.PopModalAsync();
            }
        });
        public Command PickPhotosAsyncCommand => field ??= new Command(async () =>
        {
            var nav = Application.Current?.MainPage;
            List<FileResult>? photo = await MediaPicker.Default.PickPhotosAsync();
            if (photo != null && nav != null)
                try
                {
                    await photo?.FirstOrDefault()?.OpenReadAsync();
                } catch (Exception ex)
                {
                    await nav.DisplayAlertAsync("Could not open photo", ex.Message, "OK");
                }
            else if (nav != null)
            {
                await nav.DisplayAlertAsync("No photo selected", "You did not select a photo.", "OK");
            }
        });
        public Command TakePhotoAsyncCommand => field ??= new Command(async () =>
        {
            FileResult? photo = await MediaPicker.Default.CapturePhotoAsync();
            if (photo != null)
                await photo?.OpenReadAsync();
        });
    }
}
