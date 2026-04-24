using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using IT3048FinalNationalParksApp.Services;

namespace IT3048FinalNationalParksApp.Views;

public class ParkDetailsViewModel : INotifyPropertyChanged
{
    public string ParkName { get; }
    public string Location { get; }
    public string ImageUrl { get; }
    public string Description { get; }

    public ICommand MarkVisitedCommand { get; }

    public bool IsVisited => ParksVisitedService.IsVisited(ParkName);

    public string VisitButtonText => IsVisited ? "Visited" : "Mark as Visited";

    public ParkDetailsViewModel(string parkName, string location, string imageUrl, string description)
    {
        ParkName = parkName;
        Location = location;
        ImageUrl = imageUrl;
        Description = description;

        MarkVisitedCommand = new Command(OnMarkVisited);
    }

    private void OnMarkVisited()
    {
        ParksVisitedService.SetVisited(ParkName, true);
        OnPropertyChanged(nameof(IsVisited));
        OnPropertyChanged(nameof(VisitButtonText));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}