using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSharpAdvancedOpdracht.Data;
using CSharpAdvancedOpdracht.Models;

namespace CSharpAdvancedOpdracht.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandlordsController : ControllerBase
    {
        private readonly CSharpAdvancedOpdrachtContext _context;

        public LandlordsController(CSharpAdvancedOpdrachtContext context)
        {
            _context = context;
        }

        // GET: api/Landlords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Landlords>>> GetLandlords()
        {
            return await _context.Landlords.ToListAsync();
        }

        // GET: api/Landlords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Landlords>> GetLandlords(int id)
        {
            var landlords = await _context.Landlords.FindAsync(id);

            if (landlords == null)
            {
                return NotFound();
            }

            return landlords;
        }

        // PUT: api/Landlords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLandlords(int id, Landlords landlords)
        {
            if (id != landlords.Id)
            {
                return BadRequest();
            }

            _context.Entry(landlords).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LandlordsExists(id))
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

        // POST: api/Landlords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Landlords>> PostLandlords(Landlords landlords)
        {
            _context.Landlords.Add(landlords);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLandlords", new { id = landlords.Id }, landlords);
        }

        // DELETE: api/Landlords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLandlords(int id)
        {
            var landlords = await _context.Landlords.FindAsync(id);
            if (landlords == null)
            {
                return NotFound();
            }

            _context.Landlords.Remove(landlords);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LandlordsExists(int id)
        {
            return _context.Landlords.Any(e => e.Id == id);
        }
    }
}
