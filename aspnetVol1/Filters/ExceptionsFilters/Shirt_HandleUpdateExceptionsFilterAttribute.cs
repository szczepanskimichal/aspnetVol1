using aspnetVol1.Models.Respozitories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aspnetVol1.Filters.ExceptionsFilters;

public class Shirt_HandleUpdateExceptionsFilterAttribute: ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        base.OnException(context);
        var strShirtId = context.RouteData.Values["id"] as string;
       if(int.TryParse(strShirtId, out int shirtId))
       {
          if (!ShirtRespozitory.ShirtExists(shirtId))
          {
             context.ExceptionHandled = true;
             context.Result = new NotFoundObjectResult($"Shirt with id {shirtId} not found anymore.");
          }
       }
    }
}