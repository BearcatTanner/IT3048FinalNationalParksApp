using IT3048FinalNationalParksApp.Views;
namespace IT3048FinalNationalParksApp.Auth;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
        BindingContext = new SignUpViewModel();
    }
}
