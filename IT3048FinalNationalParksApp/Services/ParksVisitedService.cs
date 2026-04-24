using Microsoft.Maui.Storage;

namespace IT3048FinalNationalParksApp.Services;

public static class ParksVisitedService
{
    private const string VisitedKeyPrefix = "visited_";

    public static bool IsVisited(string parkName)
    {
        if (string.IsNullOrWhiteSpace(parkName))
            return false;
        return Preferences.Get(VisitedKeyPrefix + parkName, false);
    }

    public static void SetVisited(string parkName, bool visited)
    {
        if (string.IsNullOrWhiteSpace(parkName))
            return;
        Preferences.Set(VisitedKeyPrefix + parkName, visited);
    }
}
