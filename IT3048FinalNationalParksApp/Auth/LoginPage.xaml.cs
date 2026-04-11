using IT3048FinalNationalParksApp.Views;

namespace IT3048FinalNationalParksApp.Auth;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LogInViewModel();
    }
}
