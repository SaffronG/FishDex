namespace FishDex
{
    public partial class RecordCatchPage : ContentPage
    {
        public RecordCatchPage()
        {
            InitializeComponent();
        }
        private async void OnSaveClicked(object? sender, EventArgs e)
        {
            await DisplayAlertAsync("Catch Recorded", "Your catch has been recorded successfully!", "OK");
            await Navigation.PopModalAsync();
        }
        private async void OnCancelClicked(object? snder, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}