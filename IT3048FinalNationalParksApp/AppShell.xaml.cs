using IT3048FinalNationalParksApp.Auth;
using IT3048FinalNationalParksApp.MainApp;

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
            Routing.RegisterRoute("EditProfilePage", typeof(EditProfilePage));
            Routing.RegisterRoute("ParkDetails", typeof(ParkDetailsPage));

        }
    }
}
