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
    public class SensorLogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SensorLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SensorLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorLog>>> GetSensorLog()
        {
            return await _context.SensorLog.ToListAsync();
        }

        // GET: api/SensorLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorLog>> GetSensorLog(string id)
        {
            var sensorLog = await _context.SensorLog.FindAsync(id);

            if (sensorLog == null)
            {
                return NotFound();
            }

            return sensorLog;
        }

        // PUT: api/SensorLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensorLog(string id, SensorLog sensorLog)
        {
            if (id != sensorLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(sensorLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorLogExists(id))
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

        // POST: api/SensorLogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SensorLog>> PostSensorLog(SensorLog sensorLog)
        {
            _context.SensorLog.Add(sensorLog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SensorLogExists(sensorLog.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSensorLog", new { id = sensorLog.Id }, sensorLog);
        }

        // DELETE: api/SensorLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SensorLog>> DeleteSensorLog(string id)
        {
            var sensorLog = await _context.SensorLog.FindAsync(id);
            if (sensorLog == null)
            {
                return NotFound();
            }

            _context.SensorLog.Remove(sensorLog);
            await _context.SaveChangesAsync();

            return sensorLog;
        }

        private bool SensorLogExists(string id)
        {
            return _context.SensorLog.Any(e => e.Id == id);
        }
    }
}
