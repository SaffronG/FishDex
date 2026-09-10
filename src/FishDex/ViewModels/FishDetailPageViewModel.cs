using System.ComponentModel;
using FishDex.Models;

namespace FishDex.ViewModels;

internal class FishDetailPageViewModel(Fish fish) : INotifyPropertyChanged
{
    public string Name { get; set; } = fish.Name;
    public string Weight { get; set; } = $"Weight: {fish.Weight} lbs";
    public string Length { get; set; } = $"Length: {fish.Length} inches";
    public string TimeCaught { get; set; } = $"Time Caught: {fish.TimeCaught}";
    public string Notes { get; set; } = fish.Notes ?? "No notes available. \nWould you like to add some?";
    public event PropertyChangedEventHandler? PropertyChanged;
    public Command CloseDetailModalCommand => field ??= new(async () =>
    {
        await Application.Current?.MainPage?.Navigation?.PopModalAsync();
    });
}
