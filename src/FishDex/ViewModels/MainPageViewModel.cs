using System.ComponentModel;
using FishDex.Models;

namespace FishDex.ViewModels;

public partial class MainPageViewModel() : INotifyPropertyChanged
{
    Page? NavHandle { get => Application.Current?.MainPage; }
    public List<Fish> FishList { get; } = 
    [
        new Fish("Bass", 5.5m, 2.0m),
        new Fish("Trout", 3.2m, 1.5m),
        new Fish("Salmon", 8.1m, 3.0m),
        new Fish("Catfish", 12.0m, 5.0m),
        new Fish("Pike", 6.8m, 2.5m),
        new Fish("Burbot", 4.5m, 1.8m),
        new Fish("Rainbow Trout", 7.3m, 2.2m)
    ];
    public Command RecordCatchClickedCommand => field ??= new Command(async () =>
    {
        if (NavHandle != null)
            await NavHandle.Navigation.PushModalAsync(new RecordCatchPage());
    });
    public Command FishTileClickedCommand => field ??= new Command<Fish>(async (fish) =>
    {
        if (NavHandle != null)
            await NavHandle.Navigation.PushModalAsync(new FishDetailPage(fish));
    });
    public event PropertyChangedEventHandler? PropertyChanged;
}
