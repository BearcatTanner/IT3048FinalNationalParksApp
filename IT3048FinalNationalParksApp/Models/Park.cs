using SQLite;

namespace IT3048FinalNationalParksApp.Models;

public class Park
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string ApiParkId { get; set; } = string.Empty;
    public string ParkCode { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string StampImage { get; set; } = string.Empty;
}