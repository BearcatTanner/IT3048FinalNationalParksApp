using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace IT3048FinalNationalParksApp.Views;

public class ParkResult
{
    public string ParkName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}

public class SearchViewModel : INotifyPropertyChanged
{
    private string _searchQuery = string.Empty;
    private bool _isLoading;
    private bool _showEmptyState = true;
    private bool _showNoResults;
    private bool _showResults;

    public string SearchQuery
    {
        get => _searchQuery;
        set { _searchQuery = value; OnPropertyChanged(); }
    }

    public bool IsLoading
    {
        get => _isLoading;
        set { _isLoading = value; OnPropertyChanged(); }
    }

    public bool ShowEmptyState
    {
        get => _showEmptyState;
        set { _showEmptyState = value; OnPropertyChanged(); }
    }

    public bool ShowNoResults
    {
        get => _showNoResults;
        set { _showNoResults = value; OnPropertyChanged(); }
    }

    public bool ShowResults
    {
        get => _showResults;
        set { _showResults = value; OnPropertyChanged(); }
    }

    public ObservableCollection<ParkResult> SearchResults { get; } = new();

    public ICommand SearchCommand { get; }
    public ICommand SelectParkCommand { get; }

    public SearchViewModel()
    {
        SearchCommand = new Command(async () => await OnSearchAsync());
        SelectParkCommand = new Command<ParkResult>(OnParkSelected);
    }

    private async Task OnSearchAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchQuery))
            return;

        IsLoading = true;
        ShowEmptyState = false;
        ShowNoResults = false;
        ShowResults = false;
        SearchResults.Clear();

        // TODO: replace with real API/service call
        // var results = await _parkService.SearchAsync(SearchQuery);
        await Task.Delay(600); // simulate network call

        // Sample data — remove when wired to real service
        var sampleResults = new List<ParkResult>
        {
            new() { ParkName = "Cuyahoga Valley", Location = "Peninsula, OH", Description = "National park along the Cuyahoga River with waterfalls and trails." },
            new() { ParkName = "Hocking Hills State Park", Location = "Logan, OH", Description = "Famous for caves, gorges, and scenic waterfalls." },
            new() { ParkName = "Wayne National Forest", Location = "Oak Hill, OH", Description = "Ohio's only national forest with extensive trail networks." },
        };

        var filtered = sampleResults
            .Where(p => p.ParkName.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)
                     || p.Location.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)
                     || p.Description.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
            .ToList();

        IsLoading = false;

        if (filtered.Count == 0)
        {
            ShowNoResults = true;
        }
        else
        {
            foreach (var r in filtered)
                SearchResults.Add(r);
            ShowResults = true;
        }
    }

    private async void OnParkSelected(ParkResult park)
    {
        if (park == null)
            return;

        // Navigate to ParkDetailsPage with the selected park details
        await Shell.Current.Navigation.PushAsync(new IT3048FinalNationalParksApp.MainApp.ParkDetailsPage(
            park.ParkName,
            park.Location,
            park.ImageUrl ?? string.Empty,
            park.Description ?? string.Empty));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}