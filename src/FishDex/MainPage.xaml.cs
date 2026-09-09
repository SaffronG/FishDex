using FishDex.ViewModels;

namespace FishDex;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        Routing.RegisterRoute("home", typeof(MainPage));
        BindingContext = new MainPageViewModel(new Services.ApiService());
    }
}