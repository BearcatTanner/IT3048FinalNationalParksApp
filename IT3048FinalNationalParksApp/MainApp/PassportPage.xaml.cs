using IT3048FinalNationalParksApp.Views;

namespace IT3048FinalNationalParksApp.MainApp;

public partial class PassportPage : ContentPage
{
    public PassportPage()
    {
        InitializeComponent();
        BindingContext = new PassportViewModel();
    }
}