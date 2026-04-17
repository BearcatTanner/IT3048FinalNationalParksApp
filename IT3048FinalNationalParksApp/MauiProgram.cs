using CommunityToolkit.Maui;
using IT3048FinalNationalParksApp.Auth;
using IT3048FinalNationalParksApp.Services;
using IT3048FinalNationalParksApp.Views; 
using Microsoft.Extensions.Logging;

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

            // Register Services
            builder.Services.AddSingleton<DatabaseService>();

            // Register ViewModels
            builder.Services.AddTransient<SignUpViewModel>();
            builder.Services.AddTransient<LogInViewModel>();

            // Register Pages
            builder.Services.AddTransient<SignUpPage>();
            builder.Services.AddTransient<LoginPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}