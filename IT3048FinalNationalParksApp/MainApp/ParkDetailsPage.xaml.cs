using IT3048FinalNationalParksApp.Views;

namespace IT3048FinalNationalParksApp.MainApp;

public partial class ParkDetailsPage : ContentPage
{
    public ParkDetailsPage(string parkName, string location, string imageUrl, string description)
    {
        InitializeComponent();
        BindingContext = new ParkDetailsViewModel(parkName, location, imageUrl, description);
    }
}