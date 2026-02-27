using aspnetVol1.Filters;
using aspnetVol1.Filters.ExceptionsFilters;
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
        [Shirt_ValidateCreateShirtFilter]
        public IActionResult CreateShirt([FromBody]Shirt shirt)
        {
            
    
            ShirtRespozitory.AddShirt(shirt);
            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.ShirtId },
                shirt);
        }


        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
       [Shirt_HandleUpdateExceptionsFilter]
        public IActionResult UpdateShirt(int id, [FromBody] Shirt shirt)
        {
            
           // if (id != shirt.ShirtId) return BadRequest();
            
                ShirtRespozitory.UpdateShirt(shirt);
         

            return NoContent();
        }
           /*
            if (shirt == null)
                return BadRequest("Shirt object is null.");

            if (id != shirt.ShirtId)
                return BadRequest($"URL id ({id}) does not match shirt id ({shirt.ShirtId}).");

            if (!ShirtRespozitory.ShirtExists(id))
                return NotFound($"Shirt with id {id} not found.");

            ShirtRespozitory.UpdateShirt(shirt);
            return NoContent();
        }
*/
        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult DeleteShirt(int id)
        {
            var shirt = ShirtRespozitory.GetShirtById(id);
            ShirtRespozitory.DeleteShirt(id);
            //shirt.Remove(shirt); --- ask Geir why this is not working!!!
            return Ok(shirt);
        }
    }
}