using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using IT3048FinalNationalParksApp.Services;
using IT3048FinalNationalParksApp.Models;

namespace IT3048FinalNationalParksApp.Views;

public class EditProfileViewModel : INotifyPropertyChanged
{
    private readonly DatabaseService _dbService;
    private string _firstName;
    private string _lastName;
    private string _email;

    public string FirstName { get => _firstName; set { _firstName = value; OnPropertyChanged(); } }
    public string LastName { get => _lastName; set { _lastName = value; OnPropertyChanged(); } }
    public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }

    public ICommand SaveCommand { get; }

    public EditProfileViewModel(DatabaseService dbService)
    {
        _dbService = dbService;
        SaveCommand = new Command(async () => await OnSaveAsync());

        // Load current data from Preferences
        var user = UserService.GetUser();
        FirstName = user.FirstName;
        LastName = user.LastName;
        Email = user.Email;
    }

    private async Task OnSaveAsync()
    {
        var session = UserService.GetUser();
        var userInDb = await _dbService.GetUserByUsername(session.Username);

        if (userInDb != null)
        {
            userInDb.FirstName = FirstName;
            userInDb.LastName = LastName;
            userInDb.Email = Email;

            await _dbService.UpdateUser(userInDb);
            UserService.SaveUser(FirstName, LastName, session.Username, Email, session.MemberSince); 

            await Shell.Current.DisplayAlert("Success", "Profile updated!", "OK");
            await Shell.Current.GoToAsync(".."); // Go back to Profile page
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}