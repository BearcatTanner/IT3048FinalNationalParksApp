namespace IT3048FinalNationalParksApp.Auth;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void LogIn_Clicked(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(Username.Text) || string.IsNullOrWhiteSpace(Password.Text))
		{
			await DisplayAlert("Error", "Please enter both username and password", "OK");
			return;
		}
		var credentials = new Dictionary<string, object>
		{
			{ "Username", Username.Text },
			{ "Password", Password.Text }
		};
        Application.Current.MainPage = new AppShell();
    }
}