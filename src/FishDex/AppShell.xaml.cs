namespace FishDex
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("RecordCatch", typeof(RecordCatchPage));
        }
    }
}
