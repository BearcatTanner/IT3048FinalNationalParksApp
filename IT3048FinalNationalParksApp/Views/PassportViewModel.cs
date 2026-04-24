using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using IT3048FinalNationalParksApp.Services;

namespace IT3048FinalNationalParksApp.Views;

public class PassportStamp
{
    public string ParkName { get; set; } = string.Empty;
    public string StampImageUrl { get; set; } = string.Empty;
    public bool IsVisited { get; set; }
    public bool IsNotVisited => !IsVisited;
    public double StampOpacity => IsVisited ? 1.0 : 0.35;
}

public class PassportViewModel : INotifyPropertyChanged
{
    public ObservableCollection<PassportStamp> Stamps { get; } = new();

    public int StampCount => Stamps.Count(s => s.IsVisited);
    public bool HasStamps => Stamps.Count > 0;
    public bool HasNoStamps => Stamps.Count == 0;

    public ICommand SelectStampCommand { get; }

    public PassportViewModel()
    {
        SelectStampCommand = new Command<PassportStamp>(OnStampSelected);
        LoadStamps();
    }

    private void LoadStamps()
    {
        var parks = new List<(string Name, string StampImage, bool Visited)>
        {
            ("Cuyahoga Valley",       "cuyahoga.png",      true),
            ("Hocking Hills",         "hockinghills.png",  true),
            ("Wayne National Forest", "wayne.png",         true),
            ("Salt Fork",             "saltfork.png",      true),
            ("Caesar Creek",          "casesarcreek.png",  true),
            ("Hueston Woods",         "huestonwoods.png",  true),
            ("Shawnee State",         "shawnee.png",       false),
            ("Zaleski State",         "zaleski.png",       false),
            ("Tar Hollow",            "tarhollow.png",     false),
            ("Mohican State",         "mohican.png",       false),
            ("Malabar Farm",          "malabar.png",       false),
            ("Nelson Kennedy Ledges", "nelsonkennedy.png", false),
        };

        foreach (var (name, stampImage, visited) in parks)
        {
            var visited = ParksVisitedService.IsVisited(name);
            Stamps.Add(new PassportStamp
            {
                ParkName = name,
                IsVisited = visited,
                StampImageUrl = stampImage
            });
        }

        OnPropertyChanged(nameof(StampCount));
        OnPropertyChanged(nameof(HasStamps));
        OnPropertyChanged(nameof(HasNoStamps));
    }

    private async void OnStampSelected(PassportStamp stamp)
    {
        if (stamp == null)
            return;

        // Open ParkDetailsPage
        await Shell.Current.Navigation.PushAsync(new IT3048FinalNationalParksApp.MainApp.ParkDetailsPage(
            stamp.ParkName,
            string.Empty,
            string.Empty,
            string.Empty));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}