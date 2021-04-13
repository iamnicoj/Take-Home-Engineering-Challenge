using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TripsAPI.Models;
using TripsAPI.Models.DTOs;
using TripsAPI.Repositories;
using TripsAPI.Process;

namespace TripsAPI.Services
{
    public class TripsService : ITripsService
    {
        public TripContext _context {get; set;}
        private readonly TripIQueryaleBuilder _queryBuilder;

        public TripsService(TripContext context)
        {
            _context = context;
            _queryBuilder = new TripIQueryaleBuilder(context);
        }

        public async Task<List<List<DistributionGroup>>> GetAllInsights(TripsQuery filters){
            
            List<List<DistributionGroup>> results = new List<List<DistributionGroup>>();
            results.Add(await this.GetDurationDistributions(filters));
            results.Add(await this.GetFareDistributions(filters));
            results.Add(await this.GetDistanceDistributions(filters));
            results.Add(await this.GetYearDistributions(filters));
            results.Add(await this.GetMonthDistributions(filters));
            results.Add(await this.GetDayDistributions(filters));
            results.Add(await this.GetHourDistributions(filters));
            results.Add(await this.GetTopPickupBoroughs(filters));
            results.Add(await this.GetTopPickupZones(filters));
            results.Add(await this.GetDurationDistributions(filters));
            results.Add(await this.GetTopDropOffBoroughs(filters));
            results.Add(await this.GetTopDropOffZones(filters));
            return results;
        }

        public async Task<List<DistributionGroup>> GetDurationDistributions(TripsQuery filters){

            var query = _queryBuilder.ApplyFiltes(filters);

            long count_subset = query.Count(p => p.DurationRange != DurationRange.Just0);

            var detailedquery = from p in query
            where p.DurationRange != DurationRange.Just0
            group p by p.DurationRange
            into g
            orderby g.Count() descending
            select new DistributionGroup  { 
                Aggregator = g.Key.ToString(), 
                Count = g.Count(), 
                Percentage = (100 * g.Count() / count_subset),
                Average = g.Average(a => a.Duration), 
                Mix = g.Min(a => a.Duration), 
                Max = g.Max(a => a.Duration), 
                Sum = g.Sum(a => a.Duration), 
                DistritutionType = nameof(GetDurationDistributions)
            };

            return await detailedquery.ToListAsync();
        }

        public async Task<List<DistributionGroup>> GetFareDistributions(TripsQuery filters){

            var query = _queryBuilder.ApplyFiltes(filters);

            long count_subset = query.Count(p => p.FareRange != FareRange.Just0);

            var detailedquery = from p in query
            where p.FareRange != FareRange.Just0
            group p by p.FareRange
            into g
            orderby g.Count() descending
            select new DistributionGroup  { 
                Aggregator = g.Key.ToString(), 
                Count = g.Count(), 
                Percentage = (100 * g.Count() / count_subset),
                Average = g.Average(a => Convert.ToDouble(a.Fare)), 
                Mix = g.Min(a => a.Fare), 
                Max = g.Max(a => a.Fare), 
                Sum = g.Sum(a => a.Fare), 
                DistritutionType = nameof(GetFareDistributions)
            };
            return await detailedquery.ToListAsync();
        }

         public async Task<List<DistributionGroup>> GetDistanceDistributions(TripsQuery filters){

            var query = _queryBuilder.ApplyFiltes(filters);

            long count_subset = query.Count(p => p.DistanceRange != DistanceRange.Just0);

            var detailedquery = from p in query
            where p.DistanceRange != DistanceRange.Just0
            group p by p.DistanceRange
            into g
            orderby g.Count() descending
            select new DistributionGroup  { 
                Aggregator = g.Key.ToString(), 
                Count = g.Count(), 
                Percentage = (100 * g.Count() / count_subset),
                Average = g.Average(a => Convert.ToDouble(a.Distance)), 
                Mix = g.Min(a => a.Distance), 
                Max = g.Max(a => a.Distance), 
                Sum = g.Sum(a => a.Distance), 
                DistritutionType = nameof(GetDistanceDistributions)
            };
            return await detailedquery.ToListAsync();
        }

        public async Task<List<DistributionGroup>> GetYearDistributions(TripsQuery filters){

            var query = _queryBuilder.ApplyFiltes(filters);

            long count_subset = query.Count();

            var detailedquery = from p in query
            group p by p.Year
            into g
            orderby g.Count() descending
            select new DistributionGroup  { 
                Aggregator = g.Key.ToString(), 
                Count = g.Count(), 
                Percentage = (100 * g.Count() / count_subset),
                Average = 0, 
                Mix = 0, 
                Max = 0, 
                Sum = 0, 
                DistritutionType = nameof(GetYearDistributions)
            };
            return await detailedquery.ToListAsync();
        }

        public async Task<List<DistributionGroup>> GetMonthDistributions(TripsQuery filters){

            var query = _queryBuilder.ApplyFiltes(filters);

            long count_subset = query.Count();

            var detailedquery = from p in query
            group p by p.Month
            into g
            orderby g.Count() descending
            select new DistributionGroup  { 
                Aggregator = g.Key.ToString(), 
                Count = g.Count(), 
                Percentage = (100 * g.Count() / count_subset),
                Average = 0, 
                Mix = 0, 
                Max = 0, 
                Sum = 0, 
                DistritutionType = nameof(GetMonthDistributions)
            };
            return await detailedquery.ToListAsync();
        }

        public async Task<List<DistributionGroup>> GetDayDistributions(TripsQuery filters){

            var query = _queryBuilder.ApplyFiltes(filters);

            long count_subset = query.Count();

            var detailedquery = from p in query
            group p by p.WeekDay
            into g
            orderby g.Count() descending
            select new DistributionGroup  { 
                Aggregator = g.Key.ToString(), 
                Count = g.Count(), 
                Percentage = (100 * g.Count() / count_subset),
                Average = 0, 
                Mix = 0, 
                Max = 0, 
                Sum = 0, 
                DistritutionType = nameof(GetDayDistributions)
            };
            return await detailedquery.ToListAsync();
        }

        public async Task<List<DistributionGroup>> GetHourDistributions(TripsQuery filters){

            var query = _queryBuilder.ApplyFiltes(filters);

            long count_subset = query.Count();

            var detailedquery = from p in query
            group p by p.Hour
            into g
            orderby g.Count() descending
            select new DistributionGroup  { 
                Aggregator = g.Key.ToString(), 
                Count = g.Count(), 
                Percentage = (100 * g.Count() / count_subset),
                Average = 0, 
                Mix = 0, 
                Max = 0, 
                Sum = 0, 
                DistritutionType = nameof(GetHourDistributions)
            };
            return await detailedquery.ToListAsync();
        }

        public async Task<List<DistributionGroup>> GetTopPickupBoroughs(TripsQuery filters){

            var query = _queryBuilder.ApplyFiltes(filters);

            long count_subset = query.Count();

            var detailedquery = from p in query
            group p by p.PickUpBorough
            into g
            orderby g.Count() descending
            select new DistributionGroup  { 
                Aggregator = g.Key.ToString(), 
                Count = g.Count(), 
                Percentage = (100 * g.Count() / count_subset),
                Average = 0, 
                Mix = 0, 
                Max = 0, 
                Sum = 0, 
                DistritutionType = nameof(GetTopPickupBoroughs)
            };
            return await detailedquery.ToListAsync();
        }

        public async Task<List<DistributionGroup>> GetTopPickupZones(TripsQuery filters){

            var query = _queryBuilder.ApplyFiltes(filters);

            long count_subset = query.Count();

            var detailedquery = from p in query
            group p by new { p.PickUpBorough, p.PickUpZone }
            into g
            orderby g.Count() descending
            select new DistributionGroup  { 
                Aggregator = g.Key.ToString(), 
                Count = g.Count(), 
                Percentage = (100 * g.Count() / count_subset),
                Average = 0, 
                Mix = 0, 
                Max = 0, 
                Sum = 0, 
                DistritutionType = nameof(GetTopPickupZones)
            };
            return await detailedquery.Take(20).ToListAsync();
        }

        public async Task<List<DistributionGroup>> GetTopDropOffBoroughs(TripsQuery filters){

            var query = _queryBuilder.ApplyFiltes(filters);

            long count_subset = query.Count();

            var detailedquery = from p in query
            group p by p.DropOffBorough
            into g
            orderby g.Count() descending
            select new DistributionGroup  { 
                Aggregator = g.Key.ToString(), 
                Count = g.Count(), 
                Percentage = (100 * g.Count() / count_subset),
                Average = 0, 
                Mix = 0, 
                Max = 0, 
                Sum = 0, 
                DistritutionType = nameof(GetTopDropOffBoroughs)
            };
            return await detailedquery.ToListAsync();
        }

        public async Task<List<DistributionGroup>> GetTopDropOffZones(TripsQuery filters){

            var query = _queryBuilder.ApplyFiltes(filters);

            long count_subset = query.Count();

            var detailedquery = from p in query
            group p by new { p.DropOffBorough, p.DropOffZone }
            into g
            orderby g.Count() descending
            select new DistributionGroup  { 
                Aggregator = g.Key.ToString(), 
                Count = g.Count(), 
                Percentage = (100 * g.Count() / count_subset),
                Average = 0, 
                Mix = 0, 
                Max = 0, 
                Sum = 0, 
                DistritutionType = nameof(GetTopDropOffZones)
            };
            return await detailedquery.Take(20).ToListAsync();
        }

     
        public async Task<List<TripInfo>> GetTripsInfo(TripsQuery filters){
            var query = _queryBuilder.ApplyFiltes(filters);
            return await query.Take(100).ToListAsync();
        }

        public async Task<TripInfo> GetTripInfo(long id)
        {
            var tripInfo = await _context.TripsInfo.FindAsync(id);
            return tripInfo;
        }

        public async Task<TripInfo> CreateTripInfo(TripInfo tripInfo)
        {
            TripDataProcessor.ComplementInfo(tripInfo, tripInfo.Operator, "nyc", "ny", _context);
            _context.TripsInfo.Add(tripInfo);
            await _context.SaveChangesAsync();

            return tripInfo;
        }
    }
}