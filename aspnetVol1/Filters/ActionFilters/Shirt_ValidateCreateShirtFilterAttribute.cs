using aspnetVol1.Data;
using aspnetVol1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aspnetVol1.Filters
{
    public class Shirt_ValidateCreateShirtFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            
            var dbContext = context.HttpContext.RequestServices.GetService<AplicationDbContext>();
            
            var shirt = context.ActionArguments["shirt"] as Shirt;
            if (shirt == null)
            {
                context.ModelState.AddModelError("shirt", "Shirt object is null.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else if (dbContext != null)
            {
                var existingShirt = dbContext.Shirts.FirstOrDefault(s => 
                    s.Brand == shirt.Brand && 
                    s.Color == shirt.Color && 
                    s.Size == shirt.Size && 
                    s.Gender == shirt.Gender);
                    
                if (existingShirt != null)
                {
                    context.ModelState.AddModelError("shirt", "Shirt with the same properties already exists.");
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
