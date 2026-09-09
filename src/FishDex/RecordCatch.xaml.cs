using FishDex.ViewModels;

namespace FishDex;
public partial class RecordCatchPage : ContentPage
{
    public RecordCatchPage()
    {
        InitializeComponent();
        Routing.RegisterRoute("RecordCatch", typeof(RecordCatchPage));

        BindingContext = new RecordCatchPageViewModel();
    }
}