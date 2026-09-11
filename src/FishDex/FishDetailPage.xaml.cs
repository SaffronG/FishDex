using FishDex.Models;
using FishDex.ViewModels;

namespace FishDex
{
    public partial class FishDetailPage : ContentPage, IQueryAttributable 
    {
        // Parameterless ctor used by XAML/runtime
        public FishDetailPage(FishDetailPageViewModel view)
        {
            InitializeComponent();
            BindingContext = view; 
        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("Fish", out var value) && value is Fish fish)
                BindingContext = fish;
        }

        // Construct with a Fish and reuse the parameterless ctor
    }
}