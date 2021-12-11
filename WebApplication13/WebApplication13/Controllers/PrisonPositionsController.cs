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
    public class PrisonPositionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PrisonPositionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PrisonPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrisonPosition>>> GetPrisonPosition()
        {
            return await _context.PrisonPosition.ToListAsync();
        }

        // GET: api/PrisonPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrisonPosition>> GetPrisonPosition(string id)
        {
            var prisonPosition = await _context.PrisonPosition.FindAsync(id);

            if (prisonPosition == null)
            {
                return NotFound();
            }

            return prisonPosition;
        }

        // PUT: api/PrisonPositions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrisonPosition(string id, PrisonPosition prisonPosition)
        {
            if (id != prisonPosition.Id)
            {
                return BadRequest();
            }

            _context.Entry(prisonPosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrisonPositionExists(id))
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

        // POST: api/PrisonPositions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PrisonPosition>> PostPrisonPosition(PrisonPosition prisonPosition)
        {
            _context.PrisonPosition.Add(prisonPosition);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrisonPositionExists(prisonPosition.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPrisonPosition", new { id = prisonPosition.Id }, prisonPosition);
        }

        // DELETE: api/PrisonPositions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrisonPosition>> DeletePrisonPosition(string id)
        {
            var prisonPosition = await _context.PrisonPosition.FindAsync(id);
            if (prisonPosition == null)
            {
                return NotFound();
            }

            _context.PrisonPosition.Remove(prisonPosition);
            await _context.SaveChangesAsync();

            return prisonPosition;
        }

        private bool PrisonPositionExists(string id)
        {
            return _context.PrisonPosition.Any(e => e.Id == id);
        }
    }
}
