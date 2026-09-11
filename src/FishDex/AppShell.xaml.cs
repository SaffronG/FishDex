namespace FishDex
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("RecordCatch", typeof(RecordCatchPage));
            Routing.RegisterRoute("Details", typeof(FishDetailPage));
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            // Routing.RegisterRoute("Profile", typeof(FishDetailPage));
        }
    }
}
