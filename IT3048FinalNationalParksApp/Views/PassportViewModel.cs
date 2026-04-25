using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace IT3048FinalNationalParksApp.Views;

public class PassportStamp : INotifyPropertyChanged
{
    public string ParkName { get; set; } = string.Empty;
    public string StampImageUrl { get; set; } = string.Empty;

    private bool _isVisited;
    public bool IsVisited
    {
        get => _isVisited;
        set
        {
            _isVisited = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsNotVisited));
            OnPropertyChanged(nameof(StampOpacity));
        }
    }

    public bool IsNotVisited => !IsVisited;
    public double StampOpacity => IsVisited ? 1.0 : 0.35;

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

public class PassportViewModel : INotifyPropertyChanged
{
    private readonly VisitedParksStore _store = VisitedParksStore.Instance;

    public ObservableCollection<PassportStamp> Stamps { get; } = new();

    public int StampCount => Stamps.Count(s => s.IsVisited);
    public bool HasStamps => Stamps.Count > 0;
    public bool HasNoStamps => Stamps.Count == 0;

    /// <summary>Tapping any stamp — visited or not — opens the details page.</summary>
    public ICommand SelectStampCommand { get; }

    public PassportViewModel()
    {
        SelectStampCommand = new Command<PassportStamp>(async stamp => await OnStampSelected(stamp));

        // Re-sync stamp visited state whenever the store changes
        _store.PropertyChanged += OnStoreChanged;

        LoadStamps();
    }

    // ── Navigation ────────────────────────────────────────────────────────────

    private async Task OnStampSelected(PassportStamp stamp)
    {
        if (stamp == null) return;

        ParkNavigationContext.SelectedStamp = stamp;
        ParkNavigationContext.SelectedPark = null;
        await Shell.Current.GoToAsync("ParkDetails");
    }

    // ── Store sync ────────────────────────────────────────────────────────────

    private void OnStoreChanged(object? sender, PropertyChangedEventArgs e)
    {
        // Refresh every stamp's IsVisited from the authoritative store
        foreach (var stamp in Stamps)
            stamp.IsVisited = _store.IsVisited(stamp.ParkName);

        OnPropertyChanged(nameof(StampCount));
    }

    // ── Data ──────────────────────────────────────────────────────────────────

    private void LoadStamps()
    {
        var parks = new List<(string Name, string StampImage)>
        {
            ("Cuyahoga Valley",       "cuyahoga.png"),
            ("Hocking Hills",         "hockinghills.png"),
            ("Wayne National Forest", "wayne.png"),
            ("Salt Fork",             "saltfork.png"),
            ("Caesar Creek",          "casesarcreek.png"),
            ("Hueston Woods",         "huestonwoods.png"),
            ("Shawnee State",         "shawnee.png"),
            ("Zaleski State",         "zaleski.png"),
            ("Tar Hollow",            "tarhollow.png"),
            ("Mohican State",         "mohican.png"),
            ("Malabar Farm",          "malabar.png"),
            ("Nelson Kennedy Ledges", "nelsonkennedy.png"),
        };

        foreach (var (name, stampImage) in parks)
        {
            Stamps.Add(new PassportStamp
            {
                ParkName = name,
                StampImageUrl = stampImage,
                IsVisited = _store.IsVisited(name),
            });
        }

        OnPropertyChanged(nameof(StampCount));
        OnPropertyChanged(nameof(HasStamps));
        OnPropertyChanged(nameof(HasNoStamps));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
