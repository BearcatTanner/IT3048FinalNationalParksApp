using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace IT3048FinalNationalParksApp.Views;

public class ParkLog
{
    public string ParkName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime VisitDate { get; set; }
    public string ParkImageUrl { get; set; } = string.Empty;
}

public partial class HomeViewModel : INotifyPropertyChanged
{
    private ParkLog? _recentLog;

    public ParkLog? RecentLog
    {
        get => _recentLog;
        set { _recentLog = value; OnPropertyChanged(); OnPropertyChanged(nameof(HasNoLogs)); }
    }

    public bool HasNoLogs => RecentLog == null;

    public ICommand GoToSearchCommand { get; }
    public ICommand GoToPassportCommand { get; }

    public HomeViewModel()
    {
        GoToSearchCommand = new Command(async () =>
            await Shell.Current.GoToAsync("//Search"));

        GoToPassportCommand = new Command(async () =>
            await Shell.Current.GoToAsync("//Passport"));

        // TODO: Load from your data service
        // RecentLog = await _parkService.GetMostRecentLogAsync();

        // Sample data — remove once wired to real data
        RecentLog = new ParkLog
        {
            ParkName = "Cuyahoga Valley",
            Location = "Peninsula, OH",
            VisitDate = DateTime.Now
        };
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}