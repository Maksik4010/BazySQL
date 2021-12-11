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
    public class PrisonersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PrisonersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Prisoners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prisoner>>> GetPrisoner()
        {
            return await _context.Prisoner.ToListAsync();
        }

        // GET: api/Prisoners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prisoner>> GetPrisoner(string id)
        {
            var prisoner = await _context.Prisoner.FindAsync(id);

            if (prisoner == null)
            {
                return NotFound();
            }

            return prisoner;
        }

        // PUT: api/Prisoners/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrisoner(string id, Prisoner prisoner)
        {
            if (id != prisoner.Id)
            {
                return BadRequest();
            }

            _context.Entry(prisoner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrisonerExists(id))
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

        // POST: api/Prisoners
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Prisoner>> PostPrisoner(Prisoner prisoner)
        {
            _context.Prisoner.Add(prisoner);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrisonerExists(prisoner.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPrisoner", new { id = prisoner.Id }, prisoner);
        }

        // DELETE: api/Prisoners/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prisoner>> DeletePrisoner(string id)
        {
            var prisoner = await _context.Prisoner.FindAsync(id);
            if (prisoner == null)
            {
                return NotFound();
            }

            _context.Prisoner.Remove(prisoner);
            await _context.SaveChangesAsync();

            return prisoner;
        }

        private bool PrisonerExists(string id)
        {
            return _context.Prisoner.Any(e => e.Id == id);
        }
    }
}
