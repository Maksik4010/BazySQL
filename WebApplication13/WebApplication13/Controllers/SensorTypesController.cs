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
    public class SensorTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SensorTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SensorTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorType>>> GetSensorType()
        {
            return await _context.SensorType.ToListAsync();
        }

        // GET: api/SensorTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorType>> GetSensorType(string id)
        {
            var sensorType = await _context.SensorType.FindAsync(id);

            if (sensorType == null)
            {
                return NotFound();
            }

            return sensorType;
        }

        // PUT: api/SensorTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensorType(string id, SensorType sensorType)
        {
            if (id != sensorType.Id)
            {
                return BadRequest();
            }

            _context.Entry(sensorType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorTypeExists(id))
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

        // POST: api/SensorTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SensorType>> PostSensorType(SensorType sensorType)
        {
            _context.SensorType.Add(sensorType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SensorTypeExists(sensorType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSensorType", new { id = sensorType.Id }, sensorType);
        }

        // DELETE: api/SensorTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SensorType>> DeleteSensorType(string id)
        {
            var sensorType = await _context.SensorType.FindAsync(id);
            if (sensorType == null)
            {
                return NotFound();
            }

            _context.SensorType.Remove(sensorType);
            await _context.SaveChangesAsync();

            return sensorType;
        }

        private bool SensorTypeExists(string id)
        {
            return _context.SensorType.Any(e => e.Id == id);
        }
    }
}
