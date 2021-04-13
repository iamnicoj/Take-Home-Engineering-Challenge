using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using TripsAPI.Models;
using TripsAPI.Services;
using TripsAPI.Models.DTOs;
using TripsAPI.Exceptions;
using TripsAPI.ActionFilters;
using TripsAPI.Telemetry;


namespace TripsAPI.Controllers
{
    [Route("api/[controller]")]
    [ServiceExceptionInterceptor]
    [ApiController]
    public class TripsInfoController : ControllerBase
    {
        private readonly ITripsService _service;
        internal readonly ITripsCustomTelemetry _telemetry;
        
        internal TripsQuery _query;

        public TripsInfoController(ITripsService tripService, ITripsCustomTelemetry telemetryservice)
        {
            _telemetry = telemetryservice;
            _service = tripService;
        }

        // GET: api/TripsInfo
        [HttpGet]
        [BuildQueryActionFilter]

        public async Task<ActionResult<IEnumerable<TripInfo>>> GetTripsInfo(
            DateTime? startdate = null, DateTime? EndDate = null, string puborough = null,
            string doborough = null, string puzone = null, string dozone = null)
        {
            return await _service.GetTripsInfo(_query);
        }

        // GET: api/allinsights
        [HttpGet]
        [Route("all")]
        [BuildQueryActionFilter]
        public async Task<ActionResult<IEnumerable<IEnumerable<DistributionGroup>>>> GetAllInsights(
            DateTime? startdate = null, DateTime? EndDate = null, string puborough = null,
            string doborough = null, string puzone = null, string dozone = null, string provider = null)
        {
            return await _service.GetAllInsights(_query);
        }

         // GET: api/Duration
        [HttpGet]
        [Route("Duration")]
        [BuildQueryActionFilter]
        public async Task<ActionResult<IEnumerable<DistributionGroup>>> GetDurationDistributions(
            DateTime? startdate = null, DateTime? EndDate = null, string puborough = null,
            string doborough = null, string puzone = null, string dozone = null, string provider = null)
        {
            return await _service.GetDurationDistributions(_query);
        }

        // GET: api/Fare
        [HttpGet]
        [Route("Fare")]
        [BuildQueryActionFilter]
        public async Task<ActionResult<IEnumerable<DistributionGroup>>> GetFareDistributions(
            DateTime? startdate = null, DateTime? EndDate = null, string puborough = null,
            string doborough = null, string puzone = null, string dozone = null, string provider = null)
        {
            return await _service.GetFareDistributions(_query);
        }


        // GET: api/Distance
        [HttpGet]
        [Route("Distance")]
        [BuildQueryActionFilter]
        public async Task<ActionResult<IEnumerable<DistributionGroup>>> GetDistanceDistributions(
            DateTime? startdate = null, DateTime? EndDate = null, string puborough = null,
            string doborough = null, string puzone = null, string dozone = null, string provider = null)
        {
            return await _service.GetDistanceDistributions(_query);
        }

        // GET: api/Years
        [HttpGet]
        [Route("Years")]
        [BuildQueryActionFilter]
        public async Task<ActionResult<IEnumerable<DistributionGroup>>> GetYearDistributions(
            DateTime? startdate = null, DateTime? EndDate = null, string puborough = null,
            string doborough = null, string puzone = null, string dozone = null, string provider = null)
        {
            return await _service.GetYearDistributions(_query);
        }

        // GET: api/Months
        [HttpGet]
        [Route("Months")]
        [BuildQueryActionFilter]
        public async Task<ActionResult<IEnumerable<DistributionGroup>>> GetMonthDistributions(
            DateTime? startdate = null, DateTime? EndDate = null, string puborough = null,
            string doborough = null, string puzone = null, string dozone = null, string provider = null)
        {
            return await _service.GetMonthDistributions(_query);
        }

        // GET: api/Weekdays
        [HttpGet]
        [Route("Weekdays")]
        [BuildQueryActionFilter]
        public async Task<ActionResult<IEnumerable<DistributionGroup>>> GetDayDistributions(
            DateTime? startdate = null, DateTime? EndDate = null, string puborough = null,
            string doborough = null, string puzone = null, string dozone = null, string provider = null)
        {
            return await _service.GetDayDistributions(_query);
        }

         // GET: api/Hours
        [HttpGet]
        [Route("Hours")]
        [BuildQueryActionFilter]
        public async Task<ActionResult<IEnumerable<DistributionGroup>>> GetHourDistributions(
            DateTime? startdate = null, DateTime? EndDate = null, string puborough = null,
            string doborough = null, string puzone = null, string dozone = null, string provider = null)
        {
            return await _service.GetHourDistributions(_query);
        }

        // GET: api/puBoroughs
        [HttpGet]
        [Route("puBoroughs")]
        [BuildQueryActionFilter]
        public async Task<ActionResult<IEnumerable<DistributionGroup>>> GetTopPickupBoroughs(
            DateTime? startdate = null, DateTime? EndDate = null, string puborough = null,
            string doborough = null, string puzone = null, string dozone = null, string provider = null)
        {
            return await _service.GetTopPickupBoroughs(_query);
        }

        // GET: api/puZones
        [HttpGet]
        [Route("puZones")]
        [BuildQueryActionFilter]
        public async Task<ActionResult<IEnumerable<DistributionGroup>>> GetTopPickupZones(
            DateTime? startdate = null, DateTime? EndDate = null, string puborough = null,
            string doborough = null, string puzone = null, string dozone = null, string provider = null)
        {
            return await _service.GetTopPickupZones(_query);
        }

        // GET: api/doBoroughs
        [HttpGet]
        [Route("doBoroughs")]
        [BuildQueryActionFilter]
        public async Task<ActionResult<IEnumerable<DistributionGroup>>> GetTopDropOffBoroughs(
            DateTime? startdate = null, DateTime? EndDate = null, string puborough = null,
            string doborough = null, string puzone = null, string dozone = null, string provider = null)
        {
            return await _service.GetTopDropOffBoroughs(_query);
        }

        // GET: api/doZones
        [HttpGet]
        [Route("doZones")]
        [BuildQueryActionFilter]
        public async Task<ActionResult<IEnumerable<DistributionGroup>>> GetTopDropOffZones(
            DateTime? startdate = null, DateTime? EndDate = null, string puborough = null,
            string doborough = null, string puzone = null, string dozone = null, string provider = null)
        {
            return await _service.GetTopDropOffZones(_query);
        }


        // GET: api/TripsInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TripInfo>> GetTripInfo(long id)
        {
            var tripInfo = await _service.GetTripInfo(id);

            if (tripInfo == null)
            {
                return NotFound();
            }

            return tripInfo;
        }


        // POST: api/TripsInfo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TripInfo>> PostTripInfo(TripInfo tripInfo)
        {

            await _service.CreateTripInfo(tripInfo);

            return CreatedAtAction("GetTripInfo", new { id = tripInfo.Id }, tripInfo);
        }
    }
}
