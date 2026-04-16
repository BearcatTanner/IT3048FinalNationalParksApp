namespace IT3048FinalNationalParksApp.MainApp;

using IT3048FinalNationalParksApp.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
		BindingContext = new ProfileViewModel();
	}
}