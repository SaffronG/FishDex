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
            Navigation.PushAsync(new RecordCatchPage());
        }
        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;
            CounterBtn.Text = $"Caught {count} fish";
            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
