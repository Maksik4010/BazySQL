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
    public class PrisonerJobsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PrisonerJobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PrisonerJobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrisonerJob>>> GetPrisonerJob()
        {
            return await _context.PrisonerJob.ToListAsync();
        }

        // GET: api/PrisonerJobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrisonerJob>> GetPrisonerJob(string id)
        {
            var prisonerJob = await _context.PrisonerJob.FindAsync(id);

            if (prisonerJob == null)
            {
                return NotFound();
            }

            return prisonerJob;
        }

        // PUT: api/PrisonerJobs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrisonerJob(string id, PrisonerJob prisonerJob)
        {
            if (id != prisonerJob.Id)
            {
                return BadRequest();
            }

            _context.Entry(prisonerJob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrisonerJobExists(id))
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

        // POST: api/PrisonerJobs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PrisonerJob>> PostPrisonerJob(PrisonerJob prisonerJob)
        {
            _context.PrisonerJob.Add(prisonerJob);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrisonerJobExists(prisonerJob.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPrisonerJob", new { id = prisonerJob.Id }, prisonerJob);
        }

        // DELETE: api/PrisonerJobs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrisonerJob>> DeletePrisonerJob(string id)
        {
            var prisonerJob = await _context.PrisonerJob.FindAsync(id);
            if (prisonerJob == null)
            {
                return NotFound();
            }

            _context.PrisonerJob.Remove(prisonerJob);
            await _context.SaveChangesAsync();

            return prisonerJob;
        }

        private bool PrisonerJobExists(string id)
        {
            return _context.PrisonerJob.Any(e => e.Id == id);
        }
    }
}
