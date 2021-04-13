using TripsAPI.Models;
using TinyCsvParser.Mapping;


namespace TripsAPI.Repositories.Seeders
{
    public class YellowMapping : CsvMapping<TripInfo>
    {
        public YellowMapping()
            : base()
        {
            MapProperty(1, x => x.PickupDateTime);
            MapProperty(2, x => x.DropOffDateTime);
            MapProperty(3, x => x.PassangerCount);
            MapProperty(4, x => x.Distance);
            MapProperty(7, x => x.PickUpZoneId);
            MapProperty(8, x => x.DropOffZoneId);
            MapProperty(9, x => x.PaymentType);
            MapProperty(10, x => x.Fare);
        }
    }
}