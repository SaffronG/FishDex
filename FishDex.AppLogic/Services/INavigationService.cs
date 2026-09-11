namespace FishDex.AppLogic.Services;

public interface INavigationService
{
    public Task NavigateToAsync(string route);
    public Task NavigateToAsync(string route, Dictionary<string, object> parameters);
    public Task DisplayAlertAsync(string msg, string desc, string cancel_msg);
    public Task DisplayPromptAsync(string msg, string desc);
    public Task DisplayActionSheetAsync(string title, string cancel, string desctruction, params string[] buttons);
}