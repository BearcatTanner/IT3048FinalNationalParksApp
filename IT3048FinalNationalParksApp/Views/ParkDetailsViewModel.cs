using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace IT3048FinalNationalParksApp.Views;

public class ParkDetailsViewModel : INotifyPropertyChanged
{

    private string _parkName = string.Empty;
    public string ParkName
    {
        get => _parkName;
        set { _parkName = value; OnPropertyChanged(); }
    }

    private string _location = string.Empty;
    public string Location
    {
        get => _location;
        set { _location = value; OnPropertyChanged(); }
    }

    private string _description = string.Empty;
    public string Description
    {
        get => _description;
        set { _description = value; OnPropertyChanged(); }
    }

    private string _imageUrl = string.Empty;
    public string ImageUrl
    {
        get => _imageUrl;
        set { _imageUrl = value; OnPropertyChanged(); }
    }

    private string _imageAltText = string.Empty;
    public string ImageAltText
    {
        get => _imageAltText;
        set { _imageAltText = value; OnPropertyChanged(); }
    }


    private bool _isVisited;
    public bool IsVisited
    {
        get => _isVisited;
        private set
        {
            _isVisited = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(VisitedButtonText));
            OnPropertyChanged(nameof(VisitedButtonColor));
            OnPropertyChanged(nameof(VisitedButtonTextColor));
        }
    }

    public string VisitedButtonText => IsVisited ? "Visited" : "Mark as Visited";
    public string VisitedButtonColor => IsVisited ? "#4CAF50" : "#1B3A2D";
    public string VisitedButtonTextColor => "#FFFFFF";


    public ICommand GoBackCommand { get; }
    public ICommand MarkVisitedCommand { get; }


    public ParkDetailsViewModel()
    {
        GoBackCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
        MarkVisitedCommand = new Command(OnMarkVisited);
    }


    public void LoadFromParkResult(ParkResult park)
    {
        ParkName = park.ParkName;
        Location = park.Location;
        Description = park.Description;
        ImageUrl = park.ImageUrl;
        ImageAltText = park.ImageAltText;
        IsVisited = VisitedParksStore.Instance.IsVisited(park.ParkName);
    }

    public void LoadFromPassportStamp(PassportStamp stamp)
    {
        ParkName = stamp.ParkName;
        Location = string.Empty;
        Description = string.Empty;
        ImageUrl = stamp.StampImageUrl;
        ImageAltText = stamp.ParkName;
        IsVisited = VisitedParksStore.Instance.IsVisited(stamp.ParkName);
    }


    private void OnMarkVisited()
    {
        if (IsVisited)
        {
            VisitedParksStore.Instance.MarkUnvisited(ParkName);
            IsVisited = false;
        }
        else
        {
            VisitedParksStore.Instance.MarkVisited(ParkName);
            IsVisited = true;
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
