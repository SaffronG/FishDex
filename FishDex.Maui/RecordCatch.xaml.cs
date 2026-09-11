namespace FishDex;

public partial class RecordCatchPage : ContentPage
{
    public RecordCatchPage(RecordCatchPageViewModel view)
    {
        InitializeComponent();
        BindingContext = view;
    }
}