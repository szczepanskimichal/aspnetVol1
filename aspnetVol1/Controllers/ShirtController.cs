using aspnetVol1.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetVol1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtController : ControllerBase
    {
        [HttpGet]
        //[Route("shirts")]
        public string GetShirts()
        {
            return "Reading all shirts from the database";
        }
        [HttpGet("{id}")]
        //[Route("shirts/{id}")]
        public string GetShirt(int id)
        {
            return "Reading shirt " + id;
        }
        [HttpPost]
        //[Route("shirts")]
        public string CreateShirt([FromBody]Shirt shirt)
        {
            return "Creating a new shirt in the database";
        }
        [HttpPut("{id}")]
        //[Route("shirts/{id}")]
        public string UpdateShirt(int id)
        {
            return "Updating shirt " + id;
        }
        [HttpDelete("{id}")]
        //[Route("shirts/{id}")]
        public string DeleteShirt(int id)
        {
            return "Deleting shirt " + id;
        }
    }
}