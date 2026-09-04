using System.ComponentModel;

namespace FishDex.ViewModels
{
    public partial class RecordCatchViewModel() : INotifyPropertyChanged
    {
        public Command SaveButtonClickedCommand => field ??= new Command(async () =>
        {
            var page = Application.Current?.MainPage;
            if (page != null)
            {
                await page.DisplayAlertAsync("Catch Recorded", "Your catch has been recorded successfully!", "OK");
                await page.Navigation.PopModalAsync();
            }
        });

        public Command CancelButtonClickedCommand => field ??= new Command(async () =>
        {
            var page = Application.Current?.MainPage;
            if (page != null)
            {
                await page.Navigation.PopModalAsync();
            }
        });

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
