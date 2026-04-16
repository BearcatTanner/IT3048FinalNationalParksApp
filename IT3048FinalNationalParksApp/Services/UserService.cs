using Microsoft.Maui.Storage;

namespace IT3048FinalNationalParksApp.Services;

public static class UserService
{
    private const string FirstNameKey = "user_firstname";
    private const string LastNameKey = "user_lastname";
    private const string UsernameKey = "user_username";
    private const string EmailKey = "user_email";
    private const string MemberSinceKey = "user_membersince"; // stored as ISO string

    public static void SaveUser(string firstName, string lastName, string username, string email, DateTime? memberSince = null)
    {
        Preferences.Set(FirstNameKey, firstName ?? string.Empty);
        Preferences.Set(LastNameKey, lastName ?? string.Empty);
        Preferences.Set(UsernameKey, username ?? string.Empty);
        Preferences.Set(EmailKey, email ?? string.Empty);
        Preferences.Set(MemberSinceKey, (memberSince ?? DateTime.UtcNow).ToString("o"));
    }

    public static (string FirstName, string LastName, string Username, string Email, DateTime MemberSince) GetUser()
    {
        var firstName = Preferences.Get(FirstNameKey, string.Empty);
        var lastName = Preferences.Get(LastNameKey, string.Empty);
        var username = Preferences.Get(UsernameKey, string.Empty);
        var email = Preferences.Get(EmailKey, string.Empty);
        var memberSinceStr = Preferences.Get(MemberSinceKey, string.Empty);
        DateTime memberSince = DateTime.UtcNow;
        if (!string.IsNullOrWhiteSpace(memberSinceStr) && DateTime.TryParse(memberSinceStr, null, System.Globalization.DateTimeStyles.RoundtripKind, out var dt))
            memberSince = dt;

        return (firstName, lastName, username, email, memberSince);
    }

    public static void ClearUser()
    {
        Preferences.Remove(FirstNameKey);
        Preferences.Remove(LastNameKey);
        Preferences.Remove(UsernameKey);
        Preferences.Remove(EmailKey);
        Preferences.Remove(MemberSinceKey);
    }
}
