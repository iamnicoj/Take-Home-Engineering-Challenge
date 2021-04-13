namespace TripsAPI.Models.DTOs
{
    public class DistributionGroup
    {
        public string DistritutionType { get; set; }
        public string Aggregator { get; set; }
        public long Count { get; set; }

        public decimal Percentage { get; set; }
        public double Average { get; set; }
        public decimal Max { get; set; }
        public decimal Mix { get; set; }
        public decimal Sum { get; set; }
    }
    
}