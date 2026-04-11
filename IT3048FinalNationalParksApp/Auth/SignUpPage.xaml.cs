namespace IT3048FinalNationalParksApp.Auth;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
	}

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Firstname.Text) ||
                string.IsNullOrWhiteSpace(Lastname.Text) ||
                string.IsNullOrWhiteSpace(Username.Text) ||
                string.IsNullOrWhiteSpace(Email.Text) ||
                string.IsNullOrWhiteSpace(Password.Text) ||
                string.IsNullOrWhiteSpace(ConfirmPassword.Text))
        {
            await DisplayAlert("Error", "Please fill out all the fields", "OK");
            return;
        }

        if (!EmailValidator.IsValid)
        {
            await DisplayAlert("Error", "Please enter a valid email address", "OK");
            return;
        }

        if (Password.Text != ConfirmPassword.Text)
        {
            await DisplayAlert("Error", "Passwords do not match", "OK");
            return;
        }

        var userData = new Dictionary<string, object>
        {
            { "FirstName", Firstname.Text },
            { "LastName", Lastname.Text },
            { "Username", Username.Text },
            { "Email", Email.Text },
            { "Password", Password.Text }
        };

        await Shell.Current.GoToAsync("//Home");
    }
}