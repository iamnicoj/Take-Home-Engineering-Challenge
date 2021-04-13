using TripsAPI.Models;
using TinyCsvParser.Mapping;


namespace TripsAPI.Repositories.Seeders
{
    public class FhvMapping : CsvMapping<TripInfo>
    {
        public FhvMapping()
            : base()
        {
            MapProperty(1, x => x.PickupDateTime);
            MapProperty(2, x => x.DropOffDateTime);
            MapProperty(3, x => x.PickUpZoneId);
            MapProperty(4, x => x.DropOffZoneId);
        }
    }
}