using IT3048FinalNationalParksApp.Auth;

namespace IT3048FinalNationalParksApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Auth pages are routes, not tabs — so they never show the tab bar
            Routing.RegisterRoute("SignUpPage", typeof(SignUpPage));
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
        }
    }
}
