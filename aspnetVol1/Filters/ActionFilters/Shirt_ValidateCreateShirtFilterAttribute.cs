using aspnetVol1.Models;
using aspnetVol1.Models.Respozitories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aspnetVol1.Filters
{
    public class Shirt_ValidateCreateShirtFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var shirt = context.ActionArguments["shirt"] as Shirt;
            if (shirt == null)
            {
                context.ModelState.AddModelError("shirtId", "ShirtId object is null.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingShirt = ShirtRespozitory.GetShirtByProperties(shirt.Brand, shirt.Color, shirt.Size, shirt.Gender);
                if (existingShirt != null)
                {
                    context.ModelState.AddModelError("shirtId", "ShirtId already exists.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}   
// if (shirt == null) 
//     return BadRequest("Invalid shirt data.");
//     
// var existingShirt = ShirtRespozitory.GetShirtByProperties(shirt.Brand, shirt.Color, shirt.Size, shirt.Gender);
// if(existingShirt != null) 
//     return BadRequest("Shirt with the same properties already exists.");