using IT3048FinalNationalParksApp.Services;
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
    public string ImageAltText { get; set; } = string.Empty;
}

public class SearchViewModel : INotifyPropertyChanged
{
    private string _searchQuery = string.Empty;
    private bool _ohSelected = true;
    private bool _kySelected = true;
    private bool _inSelected = true;
    private bool _isLoading;
    private bool _showEmptyState = true;
    private bool _showNoResults;
    private bool _showResults;

    public string SearchQuery
    {
        get => _searchQuery;
        set { _searchQuery = value; OnPropertyChanged(nameof(SearchQuery)); }
    }

    public bool OHSelected
    {
        get => _ohSelected;
        set { _ohSelected = value; OnPropertyChanged(nameof(OHSelected)); }
    }

    public bool KYSelected
    {
        get => _kySelected;
        set { _kySelected = value; OnPropertyChanged(nameof(KYSelected)); }
    }

    public bool INSelected
    {
        get => _inSelected;
        set { _inSelected = value; OnPropertyChanged(nameof(INSelected)); }
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
        if (string.IsNullOrWhiteSpace(_searchQuery))
            return;

        IsLoading = true;
        ShowEmptyState = false;
        ShowNoResults = false;
        ShowResults = false;
        SearchResults.Clear();

        var api = new APIService();
        var results = new List<ParkResult>();
        var q = SearchQuery.ToLower();

        try
        {
            if (INSelected)
            {
                var inResponse = await api.GETParksQueryIN(q);
                var returnedParks = inResponse.Data.ToList();
               
                    foreach (var p in returnedParks)
                    {
                    results.Add(new ParkResult
                    {
                        ParkName = p.FullName ?? string.Empty,
                        ImageUrl = p.Images != null && p.Images.Count > 0 ? p.Images[0].Url ?? string.Empty : string.Empty,
                        ImageAltText = p.Images != null && p.Images.Count > 0 ? p.Images[0].AltText ?? string.Empty : string.Empty,
                        Location = p.Addresses != null && p.Addresses.Count > 0 ? p.Addresses[0].StateCode ?? string.Empty : string.Empty,
                    });
                    }
                }
            

            if (OHSelected)
            {
                var ohResponse = await api.GETParksQueryOH(q);
                if (ohResponse != null)
                {
                    //foreach (var p in ohResponse.data)
                    //{
                    //    results.Add(new ParkResult
                    //    {
                    //        ParkName = p.fullName ?? string.Empty,
                    //        Location = p.states ?? string.Empty,
                    //        Description = p.description ?? string.Empty,
                    //        ImageUrl = p.images != null && p.images.Count > 0 ? p.images[0].url ?? string.Empty : string.Empty
                    //    });
                    //}
                }
            }

            if (KYSelected)
            {
                var kyResponse = await api.GETParksQueryKY(q);
                if (kyResponse != null)
                {
                    //foreach (var p in kyResponse.data)
                    //{
                    //    results.Add(new ParkResult
                    //    {
                    //        ParkName = p.fullName ?? string.Empty,
                    //        Location = p.states ?? string.Empty,
                    //        Description = p.description ?? string.Empty,
                    //        ImageUrl = p.images != null && p.images.Count > 0 ? p.images[0].url ?? string.Empty : string.Empty
                    //    });
                    //}
                }
            }

            // remove duplicate parks (same name) that can appear across multiple calls
            var distinct = results
                .GroupBy(r => r.ParkName)
                .Select(g => g.First())
                .ToList();

            IsLoading = false;

            if (distinct.Count == 0)
            {
                ShowNoResults = true;
            }
            else
            {
                foreach (var r in distinct)
                    SearchResults.Add(r);
                ShowResults = true;
            }
        }
        catch
        {
            IsLoading = false;
            ShowNoResults = true;
        }

        //var results = await APIService.SearchAsync(SearchQuery);
        //await Task.Delay(600); // simulate network call

        //// Sample data — remove when wired to real service
        //var sampleResults = new List<ParkResult>
        //{
        //    new() { ParkName = "Cuyahoga Valley", Location = "Peninsula, OH", Description = "National park along the Cuyahoga River with waterfalls and trails." },
        //    new() { ParkName = "Hocking Hills State Park", Location = "Logan, OH", Description = "Famous for caves, gorges, and scenic waterfalls." },
        //    new() { ParkName = "Wayne National Forest", Location = "Oak Hill, OH", Description = "Ohio's only national forest with extensive trail networks." },
        //};

        //var filtered = sampleResults
        //    .Where(p => p.ParkName.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)
        //             || p.Location.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)
        //             || p.Description.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        //    .ToList();

        //IsLoading = false;

        //if (filtered.Count == 0)
        //{
        //    ShowNoResults = true;
        //}
        //else
        //{
        //    foreach (var r in filtered)
        //        SearchResults.Add(r);
        //    ShowResults = true;
        //}
    }

    private void OnParkSelected(ParkResult park)
    {
        // TODO: navigate to park detail page
        // await Shell.Current.GoToAsync($"ParkDetailPage?parkId={park.ParkId}");
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}