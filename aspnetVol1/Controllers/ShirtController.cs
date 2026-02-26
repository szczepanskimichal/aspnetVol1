using System.Drawing;
using aspnetVol1.Filters;
using aspnetVol1.Models;
using aspnetVol1.Models.Respozitories;
using Microsoft.AspNetCore.Mvc;

namespace aspnetVol1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtController : ControllerBase
    { 
        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok(ShirtRespozitory.GetShirts());
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        //public string GetShirtById(int id)
        public IActionResult GetShirtById(int id)
        {
            return Ok(ShirtRespozitory.GetShirtById(id));
        }

        [HttpPost]
        public IActionResult CreateShirt([FromBody]Shirt shirt)
        {
            if (shirt == null) 
                return BadRequest("Invalid shirt data.");
    
            var existingShirt = ShirtRespozitory.GetShirtByProperties(shirt.Brand, shirt.Color, shirt.Size, shirt.Gender);
            if(existingShirt != null) 
                return BadRequest("Shirt with the same properties already exists.");
    
            ShirtRespozitory.AddShirt(shirt);
            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.ShirtId },
                shirt);
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