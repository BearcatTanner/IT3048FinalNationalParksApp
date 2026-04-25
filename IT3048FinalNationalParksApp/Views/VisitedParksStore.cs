using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IT3048FinalNationalParksApp.Views;

/// Singleton store that holds the set of visited park names.

public class VisitedParksStore : INotifyPropertyChanged
{
    public static readonly VisitedParksStore Instance = new();
    private VisitedParksStore() { }


    private readonly HashSet<string> _visitedNames = new(StringComparer.OrdinalIgnoreCase)
    {
        // Seeded with the parks that were already hard-coded as visited
        "Cuyahoga Valley",
        "Hocking Hills",
        "Wayne National Forest",
        "Salt Fork",
        "Caesar Creek",
        "Hueston Woods",
    };


    public bool IsVisited(string parkName) => _visitedNames.Contains(parkName);


    public void MarkVisited(string parkName)
    {
        if (_visitedNames.Add(parkName))
            OnPropertyChanged(nameof(VisitedSetChanged));
    }


    public void MarkUnvisited(string parkName)
    {
        if (_visitedNames.Remove(parkName))
            OnPropertyChanged(nameof(VisitedSetChanged));
    }

    public bool VisitedSetChanged => true;


    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
