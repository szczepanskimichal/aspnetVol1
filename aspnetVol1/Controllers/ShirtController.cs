using System.Drawing;
using aspnetVol1.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetVol1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtController : ControllerBase
    {
        private static List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt { ShirtId = 1, Brand = "Nike", Color = "Red", Gender = "Men", Size = 10, Price = 29.99 },
            new Shirt { ShirtId = 2, Brand = "Adidas", Color = "Blue", Gender = "Men", Size = 22, Price = 122.88 },
            new Shirt { ShirtId = 3, Brand = "Under Armour", Color = "Green", Gender = "Men", Size = 6, Price = 19.99 },
            new Shirt { ShirtId = 4, Brand = "Puma", Color = "Black", Gender = "Men", Size = 8, Price = 24.99 }
        };

        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok("Reading all shirts from the database");
        }

        [HttpGet("{id}")]
        //public string GetShirtById(int id)
        public IActionResult GetShirtById(int id)
        {
            if (id <=0) return BadRequest();
            
            var shirt = shirts.FirstOrDefault(x => x.ShirtId == id);
            if (shirt == null)
                //return $"Shirt {id} not found";
                return NotFound();
            
            //return $"Reading shirt {id}: {shirt.Brand} {shirt.Color} {shirt.Gender} {shirt.Size} {shirt.Price}";
            return Ok(shirt);
        }

        [HttpPost]
        public IActionResult CreateShirt([FromBody]Shirt shirt)
        {
            return Ok($"Creating a new shirt: {shirt.Brand} {shirt.Color}, size {shirt.Size} in the database");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShirt(int id, [FromBody]Shirt shirt)
        {
            return Ok($"Updating shirt {id}: {shirt.Brand} {shirt.Color}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShirt(int id)
        {
            return Ok($"Deleting shirt {id}");
        }
    }
}