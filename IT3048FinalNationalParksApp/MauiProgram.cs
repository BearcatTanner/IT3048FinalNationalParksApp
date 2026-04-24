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

            // 1. Register Data Services
            builder.Services.AddSingleton<DatabaseService>();

            // 2. Register ViewModels 
            builder.Services.AddTransient<SignUpViewModel>();
            builder.Services.AddTransient<LogInViewModel>();
            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<EditProfileViewModel>();

            // 3. Register Pages
            builder.Services.AddTransient<SignUpPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<EditProfilePage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}