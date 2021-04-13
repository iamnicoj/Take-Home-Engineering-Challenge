
using TinyCsvParser.Mapping;
using TripsDataIngetion.Models;

namespace TripsDataIngetion.CsvMappers
{
    public static class TripsCvsFactory
    {
        public static CsvMapping<TripInfo> GetMapper(string name, out ServiceType provider)
        {
            if (name.ToLower().Contains("green")){
                provider = ServiceType.Green;
                return new GreenMapping();
            }
            if (name.ToLower().Contains("yellow")){
                provider = ServiceType.Yellow;
                return new GreenMapping();
            }
            if (name.ToLower().Contains("fhv")){
                provider = ServiceType.FHV;
                return new GreenMapping();
            }

            throw new System.Exception("Unable to map to a provider based on the file name");
        }
    }
    
}