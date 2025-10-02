using Microsoft.Extensions.Logging;
using AplicativoTesteTecnicoKogui.Services;
using Microsoft.Extensions.DependencyInjection;
using AplicativoTesteTecnicoKogui.ViewModels;



namespace AplicativoTesteTecnicoKogui
{
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

            builder.Services.AddHttpClient<IColorApiService, ColorApiService>(client =>
            {
                client.BaseAddress = new Uri("https://www.thecolorapi.com/");
                client.Timeout = TimeSpan.FromSeconds(10);
            });

            builder.Services.AddTransient<AppShell>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
