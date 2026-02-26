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
            return Ok("Reading all shirts from the database");
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