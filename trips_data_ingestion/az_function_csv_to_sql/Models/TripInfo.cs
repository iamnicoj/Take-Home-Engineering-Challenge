using System;
using System.Text.Json.Serialization;

namespace TripsDataIngetion.Models
{
    public class TripInfo
    {
        public Guid Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public DateTime PickupDateTime { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Hour { get; set; }
        public string WeekDay { get; set; }

        public DateTime DropOffDateTime { get; set; }

        public int PassangerCount { get; set; }
        public int PaymentType { get; set; }
        public decimal Fare { get; set; }

        // [JsonConverter(typeof(JsonStringEnumConverter))]
        public TripsDataIngetion.Models.FareRange FareRange { get; set; }
        public decimal Distance { get; set; }

        // [JsonConverter(typeof(JsonStringEnumConverter))]
        public DistanceRange DistanceRange { get; set; }
        
        public int Duration { get; set; }

        // [JsonConverter(typeof(JsonStringEnumConverter))]
        public DurationRange DurationRange { get; set; }
        

        // [JsonConverter(typeof(JsonStringEnumConverter))]
        public ServiceType Operator { get; set; }


        public int DropOffZoneId { get; set; }
        public string DropOffBorough { get; set; }
        public string DropOffZone { get; set; }


        public int PickUpZoneId { get; set; }
        public string PickUpBorough { get; set; }
        public string PickUpZone { get; set; }
        
    }
}