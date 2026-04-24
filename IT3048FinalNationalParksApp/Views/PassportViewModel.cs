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
        // TODO: replace with real service call
        var parks = new List<string>
        {
            "Cuyahoga Valley",
            "Hocking Hills",
            "Wayne National Forest",
            "Salt Fork",
            "Caesar Creek",
            "Hueston Woods",
            "Shawnee State",
            "Zaleski State",
            "Tar Hollow",
            "Mohican State",
            "Malabar Farm",
            "Nelson Kennedy Ledges",
        };

        foreach (var name in parks)
        {
            var visited = ParksVisitedService.IsVisited(name);
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