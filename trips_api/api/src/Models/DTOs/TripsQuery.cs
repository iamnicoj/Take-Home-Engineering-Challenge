using System;
using System.Collections.Generic;
using TripsAPI.Models;

namespace TripsAPI.Models.DTOs
{
    public class TripsQuery
    {
        public DateTime? StartDateTimeFilter { get; set; }
        public DateTime? EndDateTimeFilter { get; set; }

        public string PickUpBoroughFilter { get; set; }
        public string DropOffBoroughFilter { get; set; }

        public string PickUpZoneFilter { get; set; }
        public string DropOffZoneFilter { get; set; }

        public ServiceType? ServiceTypeFilter { get; set; }

    }
}