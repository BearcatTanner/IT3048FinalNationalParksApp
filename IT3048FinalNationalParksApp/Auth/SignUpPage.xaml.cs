namespace IT3048FinalNationalParksApp.Auth;

using IT3048FinalNationalParksApp.Views;

public partial class SignUpPage : ContentPage
{
    public SignUpPage(SignUpViewModel viewModel) 
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}