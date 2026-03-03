using aspnetVol1.Data;
using aspnetVol1.Filters;
using aspnetVol1.Filters.ActionFilters;
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
        private readonly AplicationDbContext _db;

        public ShirtController(AplicationDbContext db)
        {
            this._db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetShirts()
        {
            return Ok(_db.Shirts.ToList());
        }

        [HttpGet("{id}")]
        //[Shirt_ValidateShirtIdFilte]
        [TypeFilter((typeof(Shirt_ValidateShirtIdFilterAttribute)))]
        public async Task<IActionResult> GetShirtById(int id)
        {
            return Ok(HttpContext.Items["shirt"]);
        }

        [HttpPost]
        //[Shirt_ValidateCreateShirtFilter]
        [TypeFilter((typeof(Shirt_ValidateCreateShirtFilterAttribute)))]
        public async Task<IActionResult> CreateShirt([FromBody]Shirt shirt)
        {
            this._db.Shirts.Add(shirt);
            this._db.SaveChanges();
            
            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.ShirtId },
                shirt);
        }

        [HttpPut("{id}")]
        //[Shirt_ValidateShirtIdFilter]
        [TypeFilter((typeof(Shirt_ValidateShirtIdFilterAttribute)))]
        [Shirt_ValidateUpdateShirtFilter]
        //[Shirt_HandleUpdateExceptionsFilter]
        [TypeFilter(typeof(Shirt_HandleUpdateExceptionsFilterAttribute))]
        public async Task<IActionResult> UpdateShirt(int id, [FromBody] Shirt shirt)
        {
            var shirtToUpdate = HttpContext.Items["shirt"] as Shirt;
            if (shirtToUpdate == null)
            {
                return NotFound();
            }

            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Gender = shirt.Gender;

            _db.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Shirt_ValidateShirtIdFilter]
        [TypeFilter((typeof(Shirt_ValidateShirtIdFilterAttribute)))]
        public async Task<IActionResult> DeleteShirt(int id)
        {
            var shirtToDelete = await _db.Shirts.FindAsync(id);
            if (shirtToDelete == null)
            {
                return NotFound();
            }

            _db.Shirts.Remove(shirtToDelete);
            await _db.SaveChangesAsync();

            return Ok(shirtToDelete);
        }
    }
}