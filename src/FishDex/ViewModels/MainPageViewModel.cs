using System.ComponentModel;

namespace FishDex.ViewModels;

public partial class MainPageViewModel() : INotifyPropertyChanged
{
    public List<string> FishList { get; } = 
    [
        "Bass", "Trout", "Salmon", "Catfish", "Pike", "Burbot", "Rainbow Trout"
    ];
    public Command RecordCatchClickedCommand => field ??= new Command(async () =>
    {
        var nav = Application.Current?.MainPage?.Navigation;
        if (nav != null)
            await nav.PushModalAsync(new RecordCatchPage());
    });
    public event PropertyChangedEventHandler? PropertyChanged;
}
