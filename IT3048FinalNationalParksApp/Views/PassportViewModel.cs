using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IT3048FinalNationalParksApp.Views;

public class PassportStamp
{
    public string ParkName { get; set; } = string.Empty;
    public string StampImageUrl { get; set; } = string.Empty;
    public bool IsVisited { get; set; }
    public bool IsNotVisited => !IsVisited;
}

public class PassportViewModel : INotifyPropertyChanged
{
    public ObservableCollection<PassportStamp> Stamps { get; } = new();

    public int StampCount => Stamps.Count(s => s.IsVisited);
    public bool HasStamps => Stamps.Count > 0;
    public bool HasNoStamps => Stamps.Count == 0;

    public PassportViewModel()
    {
        LoadStamps();
    }

    private void LoadStamps()
    {
        // TODO: replace with real service call
        // var stamps = await _parkService.GetPassportStampsAsync();

        var parks = new List<(string Name, bool Visited)>
        {
            ("Cuyahoga Valley",      true),
            ("Hocking Hills",        true),
            ("Wayne National Forest",true),
            ("Salt Fork",            true),
            ("Caesar Creek",         true),
            ("Hueston Woods",        true),
            ("Shawnee State",        false),
            ("Zaleski State",        false),
            ("Tar Hollow",           false),
            ("Mohican State",        false),
            ("Malabar Farm",         false),
            ("Nelson Kennedy Ledges",false),
        };

        foreach (var (name, visited) in parks)
        {
            Stamps.Add(new PassportStamp
            {
                ParkName = name,
                IsVisited = visited,
                StampImageUrl = visited ? "stamp_placeholder.png" : string.Empty
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