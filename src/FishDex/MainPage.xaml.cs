using FishDex.ViewModels;

namespace FishDex;

public partial class MainPage : ContentPage
{

    public MainPage(MainPageViewModel view)
    {
        InitializeComponent();
        Routing.RegisterRoute("home", typeof(MainPage));
        BindingContext = view;
    }
}