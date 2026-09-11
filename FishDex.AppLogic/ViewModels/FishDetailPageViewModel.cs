using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FishDex.AppLogic.ViewModels;

public partial class FishDetailPageViewModel(INavigationService navservice) : ObservableObject
{
    public readonly INavigationService navHandle = navservice;
    private Fish? FishInstance;
    public string Name => FishInstance?.Name ?? string.Empty;
    public string Weight => $"Weight: {FishInstance?.Weight} lbs";
    public string Length => $"Length: {FishInstance?.Length} inches";
    public string TimeCaught => $"Time Caught: {FishInstance?.TimeCaught}";
    public string Notes => string.IsNullOrWhiteSpace(FishInstance?.Notes) ? "No notes available.\nWould you like to add some?" : FishInstance.Notes;
    [RelayCommand]
    public async Task CloseDetailModal() => await navHandle.NavigateToAsync("..");
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!query.TryGetValue("Fish", out var value) || value is not Fish fish) return;

        FishInstance = fish;
        OnPropertyChanged(nameof(Name));
        OnPropertyChanged(nameof(Weight));
        OnPropertyChanged(nameof(Length));
        OnPropertyChanged(nameof(TimeCaught));
        OnPropertyChanged(nameof(Notes));
    }
}
