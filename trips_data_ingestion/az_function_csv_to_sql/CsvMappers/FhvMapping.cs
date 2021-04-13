using TripsDataIngetion.Models;
using TinyCsvParser.Mapping;

namespace TripsDataIngetion.CsvMappers
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