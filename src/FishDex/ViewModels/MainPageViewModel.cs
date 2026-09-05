using System.ComponentModel;

namespace FishDex.ViewModels;

public partial class MainPageViewModel() : INotifyPropertyChanged
{
    Page? NavHandle { get => Application.Current?.MainPage; }
    public List<string> FishList { get; } = 
    [
        "Bass", "Trout", "Salmon", "Catfish", "Pike", "Burbot", "Rainbow Trout"
    ];
    public Command RecordCatchClickedCommand => field ??= new Command(async () =>
    {
        if (NavHandle != null)
            await NavHandle.Navigation.PushModalAsync(new RecordCatchPage());
    });
    public event PropertyChangedEventHandler? PropertyChanged;
}
