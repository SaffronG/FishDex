using FishDex.ViewModels;

namespace FishDex;
public partial class RecordCatchPage : ContentPage
{
    public RecordCatchPage()
    {
        InitializeComponent();
        
        BindingContext = new RecordCatchViewModel();
    }
}