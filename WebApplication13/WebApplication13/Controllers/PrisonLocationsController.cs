using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConsoleApp2.models;
using WebApplication13.Data;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrisonLocationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PrisonLocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PrisonLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrisonLocation>>> GetPrisonLocation()
        {
            return await _context.PrisonLocation.ToListAsync();
        }

        // GET: api/PrisonLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrisonLocation>> GetPrisonLocation(string id)
        {
            var prisonLocation = await _context.PrisonLocation.FindAsync(id);

            if (prisonLocation == null)
            {
                return NotFound();
            }

            return prisonLocation;
        }

        // PUT: api/PrisonLocations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrisonLocation(string id, PrisonLocation prisonLocation)
        {
            if (id != prisonLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(prisonLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrisonLocationExists(id))
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

        // POST: api/PrisonLocations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PrisonLocation>> PostPrisonLocation(PrisonLocation prisonLocation)
        {
            _context.PrisonLocation.Add(prisonLocation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrisonLocationExists(prisonLocation.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPrisonLocation", new { id = prisonLocation.Id }, prisonLocation);
        }

        // DELETE: api/PrisonLocations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrisonLocation>> DeletePrisonLocation(string id)
        {
            var prisonLocation = await _context.PrisonLocation.FindAsync(id);
            if (prisonLocation == null)
            {
                return NotFound();
            }

            _context.PrisonLocation.Remove(prisonLocation);
            await _context.SaveChangesAsync();

            return prisonLocation;
        }

        private bool PrisonLocationExists(string id)
        {
            return _context.PrisonLocation.Any(e => e.Id == id);
        }
    }
}
