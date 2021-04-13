using System.Collections.Generic;
using System.Threading.Tasks;
using TripsAPI.Models;
using TripsAPI.Models.DTOs;
using TripsAPI.Repositories;


namespace TripsAPI.Services
{
    public interface ITripsService
    {
        TripContext _context { get; set; }

        Task<List<List<DistributionGroup>>> GetAllInsights(TripsQuery filters);
        Task<List<DistributionGroup>> GetDurationDistributions(TripsQuery filters);
        Task<List<DistributionGroup>> GetFareDistributions(TripsQuery filters);
        Task<List<DistributionGroup>> GetDistanceDistributions(TripsQuery filters);
        Task<List<DistributionGroup>> GetYearDistributions(TripsQuery filters);
        Task<List<DistributionGroup>> GetMonthDistributions(TripsQuery filters);
        Task<List<DistributionGroup>> GetDayDistributions(TripsQuery filters);
        Task<List<DistributionGroup>> GetHourDistributions(TripsQuery filters);
        Task<List<DistributionGroup>> GetTopPickupBoroughs(TripsQuery filters);
        Task<List<DistributionGroup>> GetTopPickupZones(TripsQuery filters);
        Task<List<DistributionGroup>> GetTopDropOffBoroughs(TripsQuery filters);
        Task<List<DistributionGroup>> GetTopDropOffZones(TripsQuery filters);
        Task<List<TripInfo>> GetTripsInfo(TripsQuery filters);
        Task<TripInfo> GetTripInfo(long id);
        Task<TripInfo> CreateTripInfo(TripInfo trip);
    }
}