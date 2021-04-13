
namespace TripsAPI.Models.DTOs
{
    public class TripsWithZones
    {
        public TripInfo Trip { get; set; }
        public string PickUpBorough { get; set; }
        public string PickUpZone { get; set; }
        public string DropOffBorough { get; set; }
        public string DropOffZone { get; set; }
    }
}