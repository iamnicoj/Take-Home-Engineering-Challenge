using TripsAPI.Models;
using TinyCsvParser.Mapping;


namespace TripsAPI.Repositories.Seeders
{
    public class TaxiZoneMapping : CsvMapping<TaxiZone>
    {
        public TaxiZoneMapping()
            : base()
        {
            MapProperty(0, x => x.TaxiZoneId);
            MapProperty(1, x => x.Borough);
            MapProperty(2, x => x.Zone);
        }
    }
}