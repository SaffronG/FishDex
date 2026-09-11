namespace FishDex.Services;

public class ShellNavigationService : INavigationService
{
    public async Task DisplayAlertAsync(string msg, string desc, string cancel_msg) => await Shell.Current.DisplayAlertAsync(msg, desc, cancel_msg);
    public async Task NavigateToAsync(string route, Dictionary<string, object> parameters) => await Shell.Current.GoToAsync(route, new Dictionary<string, object>(parameters));
    public async Task NavigateToAsync(string route) => await Shell.Current.GoToAsync(route);
    public async Task DisplayPromptAsync(string msg, string desc) => await Shell.Current.DisplayPromptAsync(msg, desc);
    public async Task DisplayActionSheetAsync(string title, string cancel, string desctruction, params string[] buttons) => await Shell.Current.DisplayActionSheetAsync(title, cancel, desctruction, buttons);
}