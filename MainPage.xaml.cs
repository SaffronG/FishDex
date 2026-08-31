namespace FishDex
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnRecordCatchClicked(object? sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RecordCatchPage());
        }
    }
}
