using System;
using System.Linq;
using TripsAPI.Models;
using TripsAPI.Models.DTOs;
using TripsAPI.Repositories;


namespace TripsAPI.Process
{
    public class TripIQueryaleBuilder
    {
        private readonly TripContext _context;

        public TripIQueryaleBuilder(TripContext context)
        {
            _context = context;
        }

        internal IQueryable<TripInfo> ApplyFiltes(TripsQuery filters)
        {
            IQueryable<TripInfo> query = _context.Set<TripInfo>();

            if (filters.StartDateTimeFilter is not null &&
                filters.StartDateTimeFilter > new DateTime(2000, 1, 1))
                query = query.Where(t =>
                    t.PickupDateTime >= filters.StartDateTimeFilter);

            if (filters.EndDateTimeFilter is not null &&
                filters.EndDateTimeFilter > new DateTime(2000, 1, 1))
                query = query.Where(t =>
                    t.DropOffDateTime <= filters.EndDateTimeFilter);

            if (filters.ServiceTypeFilter is not null)
                query = query.Where(t =>
                    t.Operator == filters.ServiceTypeFilter);

            if (!string.IsNullOrEmpty(filters.PickUpBoroughFilter))
                query = query.Where(t =>
                    t.PickUpBorough == filters.PickUpBoroughFilter);

            if (!string.IsNullOrEmpty(filters.PickUpZoneFilter))
                query = query.Where(t =>
                    t.PickUpZone == filters.PickUpZoneFilter);

            if (!string.IsNullOrEmpty(filters.DropOffBoroughFilter))
                query = query.Where(t =>
                    t.DropOffBorough == filters.DropOffBoroughFilter);

            if (!string.IsNullOrEmpty(filters.DropOffZoneFilter))
                query = query.Where(t =>
                    t.DropOffZone == filters.DropOffZoneFilter);

            return query;
        }
    }
}