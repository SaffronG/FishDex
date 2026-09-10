using FishDex.Services;
using FishDex.ViewModels;
using Microsoft.Extensions.Logging;

namespace FishDex;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddHttpClient("FishDexAPI", client =>
        {
            client.BaseAddress = new Uri("https://fishdexapi.azurewebsites.net/");
        });

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<RecordCatchPage>();
        builder.Services.AddSingleton<RecordCatchPageViewModel>();
        builder.Services.AddSingleton<FishDetailPage>();
        builder.Services.AddSingleton<FishDetailPageViewModel>();
        builder.Services.AddSingleton<ApiService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
