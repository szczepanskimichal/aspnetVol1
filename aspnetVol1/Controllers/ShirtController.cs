using aspnetVol1.Data;
using aspnetVol1.Filters;
using aspnetVol1.Filters.ExceptionsFilters;
using aspnetVol1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnetVol1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ShirtController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetShirts()
        {
            var shirts = await _context.Shirts.ToListAsync();
            return Ok(shirts);
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public async Task<IActionResult> GetShirtById(int id)
        {
            var shirt = await _context.Shirts.FindAsync(id);
            if (shirt == null)
                return NotFound();
            
            return Ok(shirt);
        }

        [HttpPost]
        [Shirt_ValidateCreateShirtFilter]
        public async Task<IActionResult> CreateShirt([FromBody]Shirt shirt)
        {
            _context.Shirts.Add(shirt);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.ShirtId },
                shirt);
        }

        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_HandleUpdateExceptionsFilter]
        public async Task<IActionResult> UpdateShirt(int id, [FromBody] Shirt shirt)
        {
            shirt.ShirtId = id;
            _context.Entry(shirt).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public async Task<IActionResult> DeleteShirt(int id)
        {
            var shirt = await _context.Shirts.FindAsync(id);
            if (shirt == null)
                return NotFound();
            
            _context.Shirts.Remove(shirt);
            await _context.SaveChangesAsync();
            
            return Ok(shirt);
        }
    }
}