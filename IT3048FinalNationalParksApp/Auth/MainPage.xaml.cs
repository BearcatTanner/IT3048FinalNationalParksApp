namespace IT3048FinalNationalParksApp.Auth;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("SignUpPage");

    private async void OnLoginClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("LoginPage");
}