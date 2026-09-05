using FishDex.ViewModels;

namespace FishDex;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel(new Services.ApiService());
    }
}