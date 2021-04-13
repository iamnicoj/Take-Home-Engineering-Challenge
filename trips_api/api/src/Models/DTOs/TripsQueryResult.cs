using System;
using System.Collections.Generic;

namespace TripsAPI.Models.DTOs
{
    public class TripsQueryResult
    {
        public TripsQuery tripsQuery { get; set; }
        public TimeSpan QueryDuration { get; set; }
        public List<List<DistributionGroup>> DistributionResult { get; set; }
    }
}