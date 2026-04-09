using IT3048FinalNationalParksApp.Auth;

namespace IT3048FinalNationalParksApp;

public partial class AuthShell : Shell
{
    public AuthShell()
    {
        InitializeComponent();

        // Register routes so Shell.Current.GoToAsync(nameof(...)) can find the pages
        Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
    }
}
