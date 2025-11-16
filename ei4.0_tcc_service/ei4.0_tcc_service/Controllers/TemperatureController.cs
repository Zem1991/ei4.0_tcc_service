using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemperatureDb.Data;
using TemperatureDb.Models;
using Microsoft.EntityFrameworkCore;

namespace TemperatureDb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {
        private readonly TemperatureContext _context;

        public TemperatureController(TemperatureContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemperatureRecord>>> GetTemperatures()
        {
            return await _context.Temperatures.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TemperatureRecord>> PostTemperature([FromBody] TemperatureCreateDto dto)
        {
            var record = new TemperatureRecord
            {
                Value = dto.Value,
                Timestamp = DateTime.UtcNow
            };
            _context.Temperatures.Add(record);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTemperatures), new { id = record.Id }, record);
        }
    }
}