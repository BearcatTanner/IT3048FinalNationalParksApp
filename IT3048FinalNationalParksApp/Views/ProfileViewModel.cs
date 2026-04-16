using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using IT3048FinalNationalParksApp.Services;

namespace IT3048FinalNationalParksApp.Views;

public class ProfileViewModel : INotifyPropertyChanged
{
    private string _firstName = "";
    private string _lastName = "";
    private string _username = "";
    private string _email = "";
    private DateTime _memberSince = DateTime.UtcNow;

    public string FirstName { get => _firstName; set { _firstName = value; OnPropertyChanged(); OnPropertyChanged(nameof(FullName)); } }
    public string LastName { get => _lastName; set { _lastName = value; OnPropertyChanged(); OnPropertyChanged(nameof(FullName)); } }
    public string Username { get => _username; set { _username = value; OnPropertyChanged(); } }
    public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }
    public DateTime MemberSince { get => _memberSince; set { _memberSince = value; OnPropertyChanged(); } }

    public string FullName => string.IsNullOrWhiteSpace(FirstName) && string.IsNullOrWhiteSpace(LastName)
        ? string.Empty
        : $"{FirstName} {LastName}".Trim();

    public ICommand EditProfileCommand { get; }
    public ICommand LogoutCommand { get; }

    public ProfileViewModel()
    {
        EditProfileCommand = new Command(async () => await OnEditProfileAsync());
        LogoutCommand = new Command(async () => await OnLogoutAsync());

        LoadFromPreferences();
    }

    private void LoadFromPreferences()
    {
        var (firstName, lastName, username, email, memberSince) = UserService.GetUser();

        FirstName = string.IsNullOrWhiteSpace(firstName) ? string.Empty : firstName;
        LastName = string.IsNullOrWhiteSpace(lastName) ? string.Empty : lastName;
        Username = string.IsNullOrWhiteSpace(username) ? string.Empty : username;
        Email = string.IsNullOrWhiteSpace(email) ? string.Empty : email;
        MemberSince = memberSince;

        OnPropertyChanged(nameof(FullName));
    }

    private async Task OnEditProfileAsync()
    {
        // placeholder navigation for future edit page
        await Shell.Current.GoToAsync("EditProfilePage");
    }

    private async Task OnLogoutAsync()
    {
        UserService.ClearUser();
        // Reset navigation state and go to the MainPage (pre-auth)
        await Shell.Current.GoToAsync("//MainPage");
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
