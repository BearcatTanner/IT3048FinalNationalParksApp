using IT3048FinalNationalParksApp.Views;

namespace IT3048FinalNationalParksApp.MainApp;

public partial class ParkDetailsPage : ContentPage
{
    private readonly ParkDetailsViewModel _vm;

    public ParkDetailsPage()
    {
        InitializeComponent();
        _vm = new ParkDetailsViewModel();
        BindingContext = _vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Load whichever context was set before navigation.
        if (ParkNavigationContext.SelectedPark != null)
        {
            _vm.LoadFromParkResult(ParkNavigationContext.SelectedPark);
            ParkNavigationContext.SelectedPark = null;
        }
        else if (ParkNavigationContext.SelectedStamp != null)
        {
            _vm.LoadFromPassportStamp(ParkNavigationContext.SelectedStamp);
            ParkNavigationContext.SelectedStamp = null;
        }
    }
}
