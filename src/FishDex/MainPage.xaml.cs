using FishDex.ViewModels;

namespace FishDex;

public partial class MainPage : ContentPage
{

    public MainPage(MainPageViewModel view)
    {
        InitializeComponent();
        BindingContext = view;
    }
}