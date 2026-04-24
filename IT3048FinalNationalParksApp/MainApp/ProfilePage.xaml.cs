namespace IT3048FinalNationalParksApp.MainApp;

using IT3048FinalNationalParksApp.Views;

public partial class ProfilePage : ContentPage
{
    // Inject the ViewModel through the constructor
    public ProfilePage(ProfileViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ProfileViewModel viewModel)
        {
            viewModel.LoadFromPreferences();
        }
    }
}