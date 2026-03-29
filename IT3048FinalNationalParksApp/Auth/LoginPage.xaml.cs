using IT3048FinalNationalParksApp.Services;

namespace IT3048FinalNationalParksApp.Auth;

public partial class LoginPage : ContentPage
{
    private readonly DatabaseService _dbService;

    public LoginPage()
    {
        InitializeComponent();
    }

    public LoginPage(DatabaseService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
    }

    private async void LogIn_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Username.Text) || string.IsNullOrWhiteSpace(Password.Text))
        {
            await DisplayAlert("Error", "Please enter both username and password", "OK");
            return;
        }

        if (_dbService != null)
        {
            var user = await _dbService.GetUser(Username.Text, Password.Text);

            if (user != null)
            {
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }
        else
        {
            // Fallback if _dbService is not provided
            Application.Current.MainPage = new AppShell();
        }
    }
}