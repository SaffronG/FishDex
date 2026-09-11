using FishDex.ViewModels;

namespace FishDex;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfilePageViewModel view)
	{
		InitializeComponent();
		BindingContext = view;
	}
}