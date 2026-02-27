using aspnetVol1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aspnetVol1.Filters;

public class Shirt_ValidateUpdateShirtFilterAttribute: ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        
        var id = context.ActionArguments["id"] as int?;
        var shirt = context.ActionArguments["shirt"] as Shirt;
        if(id.HasValue && shirt != null && id != shirt.ShirtId)
        {
            context.ModelState.AddModelError("ShirtId", "The id in the URL does not match the ShirtId in the request body.");
            var problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest,
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        }
    }
}