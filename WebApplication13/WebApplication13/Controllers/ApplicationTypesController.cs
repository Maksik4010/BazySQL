using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication13.Models;
using WebApplication13.Data;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApplicationTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApplicationTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationType>>> GetApplicationType()
        {
            return await _context.ApplicationType.ToListAsync();
        }

        // GET: api/ApplicationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationType>> GetApplicationType(string id)
        {
            var applicationType = await _context.ApplicationType.FindAsync(id);

            if (applicationType == null)
            {
                return NotFound();
            }

            return applicationType;
        }

        // PUT: api/ApplicationTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationType(string id, ApplicationType applicationType)
        {
            if (id != applicationType.Id)
            {
                return BadRequest();
            }

            _context.Entry(applicationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationTypeExists(id))
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

        // POST: api/ApplicationTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ApplicationType>> PostApplicationType(ApplicationType applicationType)
        {
            _context.ApplicationType.Add(applicationType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApplicationTypeExists(applicationType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetApplicationType", new { id = applicationType.Id }, applicationType);
        }

        // DELETE: api/ApplicationTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApplicationType>> DeleteApplicationType(string id)
        {
            var applicationType = await _context.ApplicationType.FindAsync(id);
            if (applicationType == null)
            {
                return NotFound();
            }

            _context.ApplicationType.Remove(applicationType);
            await _context.SaveChangesAsync();

            return applicationType;
        }

        private bool ApplicationTypeExists(string id)
        {
            return _context.ApplicationType.Any(e => e.Id == id);
        }
    }
}
