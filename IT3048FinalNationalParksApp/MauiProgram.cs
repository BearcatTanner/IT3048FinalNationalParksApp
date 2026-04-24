using CommunityToolkit.Maui;
using IT3048FinalNationalParksApp.Auth;
using IT3048FinalNationalParksApp.Services;
using IT3048FinalNationalParksApp.Views;
using Microsoft.Extensions.Logging;
using IT3048FinalNationalParksApp.MainApp;

namespace IT3048FinalNationalParksApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddTransient<SignUpPage>();
            builder.Services.AddTransient<LoginPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}