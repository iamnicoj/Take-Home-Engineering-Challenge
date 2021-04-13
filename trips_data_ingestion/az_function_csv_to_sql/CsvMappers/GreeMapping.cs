using TripsDataIngetion.Models;
using TinyCsvParser.Mapping;


namespace TripsDataIngetion.CsvMappers
{
    public class GreenMapping : CsvMapping<TripInfo>
    {
        public GreenMapping()
            : base()
        {
            MapProperty(1, x => x.PickupDateTime);
            MapProperty(2, x => x.DropOffDateTime);
            MapProperty(7, x => x.PassangerCount);
            MapProperty(8, x => x.Distance);
            MapProperty(5, x => x.PickUpZoneId);
            MapProperty(6, x => x.DropOffZoneId);
            MapProperty(17, x => x.PaymentType);
            MapProperty(9, x => x.Fare);
        }
    }
}