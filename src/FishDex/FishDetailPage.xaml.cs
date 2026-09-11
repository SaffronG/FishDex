using FishDex.ViewModels;

namespace FishDex
{
    public partial class FishDetailPage : ContentPage
    {
        public FishDetailPage(FishDetailPageViewModel view)
        {
            InitializeComponent();
            BindingContext = view;
        }
    }
}