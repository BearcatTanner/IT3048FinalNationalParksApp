using IT3048FinalNationalParksApp.Views;

namespace IT3048FinalNationalParksApp.MainApp;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        BindingContext = new HomeViewModel();
    }
}