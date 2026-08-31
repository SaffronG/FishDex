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
            // Save the catch data to the database or perform any other necessary actions
            await DisplayAlertAsync("Catch Recorded", "Your catch has been recorded successfully!", "OK");
            await Navigation.PopModalAsync();
        }

        private async void OnCancelClicked(object? snder, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}