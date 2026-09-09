using FishDex.Models;
using FishDex.ViewModels;

namespace FishDex
{
    public partial class FishDetailPage : ContentPage 
    {
        // Parameterless ctor used by XAML/runtime
        public FishDetailPage()
        {
            InitializeComponent();
            Routing.RegisterRoute("details", typeof(FishDetailPage));
        }

        // Construct with a Fish and reuse the parameterless ctor
        public FishDetailPage(Fish fish) : this()
        {
            BindingContext = new FishDetailPageViewModel(fish);
        }
    }
}