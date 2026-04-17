
namespace IT3048FinalNationalParksApp.Models
{
    internal class Parks
    {
        public class Activity
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Address
        {
            public string postalCode { get; set; }
            public string city { get; set; }
            public string stateCode { get; set; }
            public string countryCode { get; set; }
            public string provinceTerritoryCode { get; set; }
            public string line1 { get; set; }
            public string type { get; set; }
            public string line3 { get; set; }
            public string line2 { get; set; }
        }

        public class Contacts
        {
            public List<PhoneNumber> phoneNumbers { get; set; }
            public List<EmailAddress> emailAddresses { get; set; }
        }

        public class Datum
        {
            public string id { get; set; }
            public string url { get; set; }
            public string fullName { get; set; }
            public string parkCode { get; set; }
            public string description { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string latLong { get; set; }
            public List<Activity> activities { get; set; }
            public List<Topic> topics { get; set; }
            public string states { get; set; }
            public Contacts contacts { get; set; }
            public List<EntranceFee> entranceFees { get; set; }
            public List<EntrancePass> entrancePasses { get; set; }
            public List<object> fees { get; set; }
            public string directionsInfo { get; set; }
            public string directionsUrl { get; set; }
            public List<OperatingHour> operatingHours { get; set; }
            public List<Address> addresses { get; set; }
            public List<Image> images { get; set; }
            public string weatherInfo { get; set; }
            public string name { get; set; }
            public string designation { get; set; }
            public List<object> multimedia { get; set; }
            public int relevanceScore { get; set; }
        }

        public class EmailAddress
        {
            public string description { get; set; }
            public string emailAddress { get; set; }
        }

        public class EntranceFee
        {
            public string cost { get; set; }
            public string description { get; set; }
            public string title { get; set; }
        }

        public class EntrancePass
        {
            public string cost { get; set; }
            public string description { get; set; }
            public string title { get; set; }
        }

        public class Exception
        {
            public ExceptionHours exceptionHours { get; set; }
            public string startDate { get; set; }
            public string name { get; set; }
            public string endDate { get; set; }
        }

        public class ExceptionHours
        {
            public string wednesday { get; set; }
            public string monday { get; set; }
            public string thursday { get; set; }
            public string sunday { get; set; }
            public string tuesday { get; set; }
            public string friday { get; set; }
            public string saturday { get; set; }
        }

        public class Image
        {
            public string credit { get; set; }
            public string title { get; set; }
            public string altText { get; set; }
            public string caption { get; set; }
            public string url { get; set; }
        }

        public class OperatingHour
        {
            public List<Exception> exceptions { get; set; }
            public string description { get; set; }
            public StandardHours standardHours { get; set; }
            public string name { get; set; }
        }

        public class PhoneNumber
        {
            public string phoneNumber { get; set; }
            public string description { get; set; }
            public string extension { get; set; }
            public string type { get; set; }
        }

        public class Root
        {
            public string total { get; set; }
            public string limit { get; set; }
            public string start { get; set; }
            public List<Datum> data { get; set; }
        }

        public class StandardHours
        {
            public string wednesday { get; set; }
            public string monday { get; set; }
            public string thursday { get; set; }
            public string sunday { get; set; }
            public string tuesday { get; set; }
            public string friday { get; set; }
            public string saturday { get; set; }
        }

        public class Topic
        {
            public string id { get; set; }
            public string name { get; set; }
        }


    }
}