namespace FishDex.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync(string route);
        Task NavigateToAsync(string route, Dictionary<string, object> parameters);
    }
    public class ShellNavigationService : INavigationService
    {
        public async Task NavigateToAsync(string route, Dictionary<string, object> parameters)
        {
            var query = new Dictionary<string, object>(parameters);
            await Shell.Current.GoToAsync(route, query);
        }

        public async Task NavigateToAsync(string route)
        {
            await Shell.Current.GoToAsync(route);
        }
    }
}