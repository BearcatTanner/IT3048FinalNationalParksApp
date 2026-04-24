using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using IT3048FinalNationalParksApp.Services;
using Microsoft.Maui.Controls;
using IT3048FinalNationalParksApp.Models;

namespace IT3048FinalNationalParksApp.Views;

public partial class SignUpViewModel : INotifyPropertyChanged
{
    private readonly DatabaseService _dbService;
    private string _firstname = string.Empty;
    private string _lastname = string.Empty;
    private string _username = string.Empty;
    private string _email = string.Empty;
    private string _password = string.Empty;
    private string _confirmPassword = string.Empty;
    private string _errorMessage = string.Empty;

    public string Firstname
    {
        get => _firstname;
        set { _firstname = value; OnPropertyChanged(); }
    }

    public string Lastname
    {
        get => _lastname;
        set { _lastname = value; OnPropertyChanged(); }
    }

    public string Username
    {
        get => _username;
        set { _username = value; OnPropertyChanged(); }
    }

    public string Email
    {
        get => _email;
        set { _email = value; OnPropertyChanged(); }
    }

    public string Password
    {
        get => _password;
        set { _password = value; OnPropertyChanged(); }
    }

    public string ConfirmPassword
    {
        get => _confirmPassword;
        set { _confirmPassword = value; OnPropertyChanged(); }
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set { _errorMessage = value; OnPropertyChanged(); OnPropertyChanged(nameof(HasError)); }
    }

    public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

    public ICommand SignUpCommand { get; }
    public ICommand GoToLoginCommand { get; }

    public SignUpViewModel(DatabaseService dbService)
    {
        _dbService = dbService;
        SignUpCommand = new Command(async () => await OnSignUpAsync());
        GoToLoginCommand = new Command(async () =>
            await Shell.Current.GoToAsync("LoginPage"));
    }

    private async Task OnSignUpAsync()
    {
        ErrorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(Firstname) || string.IsNullOrWhiteSpace(Lastname))
        {
            ErrorMessage = "Please enter your first and last name.";
            return;
        }

        if (string.IsNullOrWhiteSpace(Username))
        {
            ErrorMessage = "Please choose a username.";
            return;
        }

        if (string.IsNullOrWhiteSpace(Email) || !Email.Contains('@'))
        {
            ErrorMessage = "Please enter a valid email address.";
            return;
        }

        if (string.IsNullOrWhiteSpace(Password) || Password.Length < 6)
        {
            ErrorMessage = "Password must be at least 6 characters.";
            return;
        }

        if (Password != ConfirmPassword)
        {
            ErrorMessage = "Passwords do not match.";
            return;
        }

        // Create the User object for the database
        var newUser = new User
        {
            FirstName = Firstname,
            LastName = Lastname,
            Username = Username,
            Email = Email,
            Password = Password // Note: Consider hashing this for security
        };

        // Save to Database
        int result = await _dbService.RegisterUser(newUser);

        if (result > 0)
        {
            // Save to Preferences for the current session
            UserService.SaveUser(firstName: Firstname, lastName: Lastname, username: Username, email: Email, memberSince: DateTime.UtcNow);

            await Shell.Current.GoToAsync("//Home");
        }
        else
        {
            ErrorMessage = "Registration failed. Please try again.";
        }

        // TODO: replace with real registration service call
        // bool success = await _auth_service.RegisterAsync(Firstname, Lastname, Username, Email, Password);

        bool success = true; // remove when wired to real service

        if (success)
        {
            // Save basic profile locally until backend exists
            UserService.SaveUser(firstName: Firstname, lastName: Lastname, username: Username, email: Email, memberSince: DateTime.UtcNow);

            // Reset navigation to Home (clear navigation stack)
            await Shell.Current.GoToAsync("//Home");
        }
        else
        {
            ErrorMessage = "Registration failed. Please try again.";
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}