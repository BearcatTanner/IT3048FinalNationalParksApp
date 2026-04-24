using IT3048FinalNationalParksApp.Views;

namespace IT3048FinalNationalParksApp.MainApp;

public partial class EditProfilePage : ContentPage
{
    public EditProfilePage(EditProfileViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}