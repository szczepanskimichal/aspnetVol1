using Microsoft.AspNetCore.Mvc;

namespace aspnetVol1.Controllers
{
    [ApiController]
    public class ShirtController : ControllerBase
    {
        [HttpGet]
        [Route("shirts")]
        public string GetShirts()
        {
            return "Reading all shirts from the database";
        }
        [HttpGet]
        [Route("shirts/{id}")]
        public string GetShirt(int id)
        {
            return "Reading shirt " + id;
        }
        [HttpPost]
        [Route("shirts")]
        public string CreateShirt()
        {
            return "Creating a new shirt in the database";
        }
        [HttpPut]
        [Route("shirts/{id}")]
        public string UpdateShirt(int id)
        {
            return "Updating shirt " + id;
        }
        [HttpDelete]
        [Route("shirts/{id}")]
        public string DeleteShirt(int id)
        {
            return "Deleting shirt " + id;
        }
    }
}