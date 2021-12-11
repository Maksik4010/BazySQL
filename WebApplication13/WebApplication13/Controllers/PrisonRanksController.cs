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
    public class PrisonRanksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PrisonRanksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PrisonRanks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrisonRank>>> GetPrisonRank()
        {
            return await _context.PrisonRank.ToListAsync();
        }

        // GET: api/PrisonRanks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrisonRank>> GetPrisonRank(string id)
        {
            var prisonRank = await _context.PrisonRank.FindAsync(id);

            if (prisonRank == null)
            {
                return NotFound();
            }

            return prisonRank;
        }

        // PUT: api/PrisonRanks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrisonRank(string id, PrisonRank prisonRank)
        {
            if (id != prisonRank.Id)
            {
                return BadRequest();
            }

            _context.Entry(prisonRank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrisonRankExists(id))
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

        // POST: api/PrisonRanks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PrisonRank>> PostPrisonRank(PrisonRank prisonRank)
        {
            _context.PrisonRank.Add(prisonRank);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrisonRankExists(prisonRank.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPrisonRank", new { id = prisonRank.Id }, prisonRank);
        }

        // DELETE: api/PrisonRanks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrisonRank>> DeletePrisonRank(string id)
        {
            var prisonRank = await _context.PrisonRank.FindAsync(id);
            if (prisonRank == null)
            {
                return NotFound();
            }

            _context.PrisonRank.Remove(prisonRank);
            await _context.SaveChangesAsync();

            return prisonRank;
        }

        private bool PrisonRankExists(string id)
        {
            return _context.PrisonRank.Any(e => e.Id == id);
        }
    }
}
