namespace IT3048FinalNationalParksApp.Views;

/// <summary>
/// Simple static holder used to pass park data when navigating to
/// <c>ParkDetailsPage</c>.  
/// </summary>
public static class ParkNavigationContext
{
    public static ParkResult? SelectedPark { get; set; }
    public static PassportStamp? SelectedStamp { get; set; }
}
