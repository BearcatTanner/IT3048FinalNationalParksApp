// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using Newtonsoft.Json;
using System.Text.Json;

public class Parks
{
    [JsonProperty("data")]
    public List<Park> Data { get; set; }
}

public class Park
{

    [JsonProperty("fullName")]
    public string FullName { get; set; }
    public List<ParkImage> Images { get; set; }
    public List<ParkLocation> Addresses { get; set; }
}

public class ParkImage
{
    [JsonProperty("altText")]
    public string AltText { get; set; }
    [JsonProperty("url")]
    public string Url { get; set; }
}

public class ParkLocation { 
    //[JsonProperty("line1")]
    //public string AddressLine1 { get; set; }
    //[JsonProperty("city")]
    //public string City { get; set; }
    [JsonProperty("stateCode")]
    public string StateCode { get; set; }

}

//public class Parks
//{
//    public class Activity
//    {
//        [JsonProperty("id")]
//        public string Id { get; set; }

//        [JsonProperty("name")]
//        public string Name { get; set; }
//    }

//    public class Address
//    {
//        [JsonProperty("postalCode")]
//        public string PostalCode { get; set; }

//        [JsonProperty("city")]
//        public string City { get; set; }

//        [JsonProperty("stateCode")]
//        public string StateCode { get; set; }

//        [JsonProperty("countryCode")]
//        public string CountryCode { get; set; }

//        [JsonProperty("provinceTerritoryCode")]
//        public string ProvinceTerritoryCode { get; set; }

//        [JsonProperty("line1")]
//        public string Line1 { get; set; }

//        [JsonProperty("type")]
//        public string Type { get; set; }

//        [JsonProperty("line3")]
//        public string Line3 { get; set; }

//        [JsonProperty("line2")]
//        public string Line2 { get; set; }
//    }

//    public class Contacts
//    {
//        [JsonProperty("phoneNumbers")]
//        public List<PhoneNumber> PhoneNumbers { get; set; }

//        [JsonProperty("emailAddresses")]
//        public List<EmailAddress> EmailAddresses { get; set; }
//    }

//    public class Data
//    {
//        [JsonProperty("id")]
//        public string Id { get; set; }

//        [JsonProperty("url")]
//        public string Url { get; set; }

//        [JsonProperty("fullName")]
//        public string FullName { get; set; }

//        [JsonProperty("parkCode")]
//        public string ParkCode { get; set; }

//        [JsonProperty("description")]
//        public string Description { get; set; }

//        [JsonProperty("latitude")]
//        public string Latitude { get; set; }

//        [JsonProperty("longitude")]
//        public string Longitude { get; set; }

//        [JsonProperty("latLong")]
//        public string LatLong { get; set; }

//        [JsonProperty("activities")]
//        public List<Activity> Activities { get; set; }

//        [JsonProperty("topics")]
//        public List<Topic> Topics { get; set; }

//        [JsonProperty("states")]
//        public string States { get; set; }

//        [JsonProperty("contacts")]
//        public Contacts Contacts { get; set; }

//        [JsonProperty("entranceFees")]
//        public List<EntranceFee> EntranceFees { get; set; }

//        [JsonProperty("entrancePasses")]
//        public List<EntrancePass> EntrancePasses { get; set; }

//        [JsonProperty("fees")]
//        public List<object> Fees { get; set; }

//        [JsonProperty("directionsInfo")]
//        public string DirectionsInfo { get; set; }

//        [JsonProperty("directionsUrl")]
//        public string DirectionsUrl { get; set; }

//        [JsonProperty("operatingHours")]
//        public List<OperatingHour> OperatingHours { get; set; }

//        [JsonProperty("addresses")]
//        public List<Address> Addresses { get; set; }

//        [JsonProperty("images")]
//        public List<Image> Images { get; set; }

//        [JsonProperty("weatherInfo")]
//        public string WeatherInfo { get; set; }

//        [JsonProperty("name")]
//        public string Name { get; set; }

//        [JsonProperty("designation")]
//        public string Designation { get; set; }

//        [JsonProperty("multimedia")]
//        public List<object> Multimedia { get; set; }

//        [JsonProperty("relevanceScore")]
//        public int RelevanceScore { get; set; }
//    }

//    public class EmailAddress
//    {
//        [JsonProperty("description")]
//        public string Description { get; set; }

//        [JsonProperty("emailAddress")]
//        public string ParkEmailAddress { get; set; }
//    }

//    public class EntranceFee
//    {
//        [JsonProperty("cost")]
//        public string Cost { get; set; }

//        [JsonProperty("description")]
//        public string Description { get; set; }

//        [JsonProperty("title")]
//        public string Title { get; set; }
//    }

//    public class EntrancePass
//    {
//        [JsonProperty("cost")]
//        public string Cost { get; set; }

//        [JsonProperty("description")]
//        public string Description { get; set; }

//        [JsonProperty("title")]
//        public string Title { get; set; }
//    }

//    public class Exception
//    {
//        [JsonProperty("exceptionHours")]
//        public ExceptionHours ExceptionHours { get; set; }

//        [JsonProperty("startDate")]
//        public string StartDate { get; set; }

//        [JsonProperty("name")]
//        public string Name { get; set; }

//        [JsonProperty("endDate")]
//        public string EndDate { get; set; }
//    }

//    public class ExceptionHours
//    {
//        [JsonProperty("wednesday")]
//        public string Wednesday { get; set; }

//        [JsonProperty("monday")]
//        public string Monday { get; set; }

//        [JsonProperty("thursday")]
//        public string Thursday { get; set; }

//        [JsonProperty("sunday")]
//        public string Sunday { get; set; }

//        [JsonProperty("tuesday")]
//        public string Tuesday { get; set; }

//        [JsonProperty("friday")]
//        public string Friday { get; set; }

//        [JsonProperty("saturday")]
//        public string Saturday { get; set; }
//    }

//    public class Image
//    {
//        [JsonProperty("credit")]
//        public string Credit { get; set; }

//        [JsonProperty("title")]
//        public string Title { get; set; }

//        [JsonProperty("altText")]
//        public string AltText { get; set; }

//        [JsonProperty("caption")]
//        public string Caption { get; set; }

//        [JsonProperty("url")]
//        public string Url { get; set; }
//    }

//    public class OperatingHour
//    {
//        [JsonProperty("exceptions")]
//        public List<Exception> Exceptions { get; set; }

//        [JsonProperty("description")]
//        public string Description { get; set; }

//        [JsonProperty("standardHours")]
//        public StandardHours StandardHours { get; set; }

//        [JsonProperty("name")]
//        public string Name { get; set; }
//    }

//    public class PhoneNumber
//    {
//        [JsonProperty("phoneNumber")]
//        public string ParkPhoneNumber { get; set; }

//        [JsonProperty("description")]
//        public string Description { get; set; }

//        [JsonProperty("extension")]
//        public string Extension { get; set; }

//        [JsonProperty("type")]
//        public string Type { get; set; }
//    }

//    public class Root
//    {
//        [JsonProperty("total")]
//        public string Total { get; set; }

//        [JsonProperty("limit")]
//        public string Limit { get; set; }

//        [JsonProperty("start")]
//        public string Start { get; set; }

//        [JsonProperty("data")]
//        public List<Data> Data { get; set; }
//    }

//    public class StandardHours
//    {
//        [JsonProperty("wednesday")]
//        public string Wednesday { get; set; }

//        [JsonProperty("monday")]
//        public string Monday { get; set; }

//        [JsonProperty("thursday")]
//        public string Thursday { get; set; }

//        [JsonProperty("sunday")]
//        public string Sunday { get; set; }

//        [JsonProperty("tuesday")]
//        public string Tuesday { get; set; }

//        [JsonProperty("friday")]
//        public string Friday { get; set; }

//        [JsonProperty("saturday")]
//        public string Saturday { get; set; }
//    }

//    public class Topic
//    {
//        [JsonProperty("id")]
//        public string Id { get; set; }

//        [JsonProperty("name")]
//        public string Name { get; set; }
//    }
//}
