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
    public class GuiltsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GuiltsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Guilts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guilt>>> GetGuilt()
        {
            return await _context.Guilt.ToListAsync();
        }

        // GET: api/Guilts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Guilt>> GetGuilt(string id)
        {
            var guilt = await _context.Guilt.FindAsync(id);

            if (guilt == null)
            {
                return NotFound();
            }

            return guilt;
        }

        // PUT: api/Guilts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuilt(string id, Guilt guilt)
        {
            if (id != guilt.Id)
            {
                return BadRequest();
            }

            _context.Entry(guilt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuiltExists(id))
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

        // POST: api/Guilts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Guilt>> PostGuilt(Guilt guilt)
        {
            _context.Guilt.Add(guilt);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GuiltExists(guilt.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGuilt", new { id = guilt.Id }, guilt);
        }

        // DELETE: api/Guilts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guilt>> DeleteGuilt(string id)
        {
            var guilt = await _context.Guilt.FindAsync(id);
            if (guilt == null)
            {
                return NotFound();
            }

            _context.Guilt.Remove(guilt);
            await _context.SaveChangesAsync();

            return guilt;
        }

        private bool GuiltExists(string id)
        {
            return _context.Guilt.Any(e => e.Id == id);
        }
    }
}
