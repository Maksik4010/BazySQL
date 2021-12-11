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
    public class GuardsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GuardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Guards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guard>>> GetGuard()
        {
            return await _context.Guard.ToListAsync();
        }

        // GET: api/Guards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Guard>> GetGuard(string id)
        {
            var guard = await _context.Guard.FindAsync(id);

            if (guard == null)
            {
                return NotFound();
            }

            return guard;
        }

        // PUT: api/Guards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuard(string id, Guard guard)
        {
            if (id != guard.Id)
            {
                return BadRequest();
            }

            _context.Entry(guard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuardExists(id))
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

        // POST: api/Guards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Guard>> PostGuard(Guard guard)
        {
            _context.Guard.Add(guard);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GuardExists(guard.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGuard", new { id = guard.Id }, guard);
        }

        // DELETE: api/Guards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guard>> DeleteGuard(string id)
        {
            var guard = await _context.Guard.FindAsync(id);
            if (guard == null)
            {
                return NotFound();
            }

            _context.Guard.Remove(guard);
            await _context.SaveChangesAsync();

            return guard;
        }

        private bool GuardExists(string id)
        {
            return _context.Guard.Any(e => e.Id == id);
        }
    }
}
