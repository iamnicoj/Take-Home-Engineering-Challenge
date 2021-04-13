using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripsAPI.Models;
using TripsAPI.Repositories;


namespace TripsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiZonesController : ControllerBase
    {
        private readonly TripContext _context;

        public TaxiZonesController(TripContext context)
        {
            _context = context;
        }

        // GET: api/TaxiZones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxiZone>>> GetTaxiZones()
        {
            return await _context.TaxiZones.ToListAsync();
        }

        // GET: api/TaxiZones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxiZone>> GetTaxiZone(int id)
        {
            var taxiZone = await _context.TaxiZones.FindAsync(id);

            if (taxiZone == null)
            {
                return NotFound();
            }

            return taxiZone;
        }

        // PUT: api/TaxiZones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxiZone(int id, TaxiZone taxiZone)
        {
            if (id != taxiZone.TaxiZoneId)
            {
                return BadRequest();
            }

            _context.Entry(taxiZone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxiZoneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TaxiZones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaxiZone>> PostTaxiZone(TaxiZone taxiZone)
        {
            _context.TaxiZones.Add(taxiZone);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TaxiZoneExists(taxiZone.TaxiZoneId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetTaxiZone), new { id = taxiZone.TaxiZoneId }, taxiZone);
        }

        // DELETE: api/TaxiZones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxiZone(int id)
        {
            var taxiZone = await _context.TaxiZones.FindAsync(id);
            if (taxiZone == null)
            {
                return NotFound();
            }

            _context.TaxiZones.Remove(taxiZone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaxiZoneExists(int id)
        {
            return _context.TaxiZones.Any(e => e.TaxiZoneId == id);
        }
    }
}
