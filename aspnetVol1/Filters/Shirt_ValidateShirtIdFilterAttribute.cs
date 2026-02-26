using aspnetVol1.Models.Respozitories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aspnetVol1.Filters;

public class Shirt_ValidateShirtIdFilterAttribute : ActionFilterAttribute
{
   public override void OnActionExecuting(ActionExecutingContext context)
   {
      base.OnActionExecuting(context);
      var shirtId = context.ActionArguments["id"] as int?;
      if (shirtId.HasValue)
      {
         if (shirtId.Value <= 0)
         {
            context.ModelState.AddModelError("shirtId", "ShirtId is invalid. ShirtId must be greater than 0.");
            var problemDetails = new ValidationProblemDetails(context.ModelState)
            {
               Status = StatusCodes.Status400BadRequest,
            };
            context.Result = new BadRequestObjectResult(problemDetails);
         }
         else if (!ShirtRespozitory.ShirtExists(shirtId.Value))
         {
            context.ModelState.AddModelError("shirtId", $"Shirt with id {shirtId.Value} not found.");
            var problemDetails = new ValidationProblemDetails(context.ModelState)
            {
               Status = StatusCodes.Status404NotFound,
            };
            context.Result = new NotFoundObjectResult(problemDetails);
         }
      }
   }
}