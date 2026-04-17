namespace IT3048FinalNationalParksApp.Auth;

using IT3048FinalNationalParksApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LogInViewModel viewModel) 
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}