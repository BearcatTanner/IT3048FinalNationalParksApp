using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace IT3048FinalNationalParksApp.Views;

public partial class LogInViewModel : INotifyPropertyChanged
{
    private string _username = string.Empty;
    private string _password = string.Empty;
    private string _errorMessage = string.Empty;

    public string Username
    {
        get => _username;
        set { _username = value; OnPropertyChanged(); }
    }

    public string Password
    {
        get => _password;
        set { _password = value; OnPropertyChanged(); }
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set { _errorMessage = value; OnPropertyChanged(); OnPropertyChanged(nameof(HasError)); }
    }

    public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

    public ICommand LoginCommand { get; }
    public ICommand GoToSignUpCommand { get; }

    public LogInViewModel()
    {
        LoginCommand = new Command(async () => await OnLoginAsync());
        GoToSignUpCommand = new Command(async () =>
            await Shell.Current.GoToAsync("SignUpPage"));
    }

    private async Task OnLoginAsync()
    {
        ErrorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Please enter your username and password.";
            return;
        }

        // TODO: replace with real auth service call
        // bool success = await _authService.LoginAsync(Username, Password);

        bool success = true; // remove when wired to real service

        if (success)
        {
            await Shell.Current.GoToAsync("//Home");
        }
        else
        {
            ErrorMessage = "Invalid username or password.";
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}