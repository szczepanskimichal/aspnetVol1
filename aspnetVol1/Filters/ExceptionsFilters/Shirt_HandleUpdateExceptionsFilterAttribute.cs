using aspnetVol1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aspnetVol1.Filters.ExceptionsFilters;

public class Shirt_HandleUpdateExceptionsFilterAttribute: ExceptionFilterAttribute
{
    private readonly AplicationDbContext db;
    public Shirt_HandleUpdateExceptionsFilterAttribute(AplicationDbContext db)
    {
        this.db = db;
    }
    public override void OnException(ExceptionContext context)
    {
        base.OnException(context);
        var strShirtId = context.RouteData.Values["id"] as string;
       if(int.TryParse(strShirtId, out int shirtId))
       {
          if (db.Shirts.FirstOrDefault(x => x.ShirtId == shirtId) == null)
          {
              context.ModelState.AddModelError("ShirtId", "Shirt doesn't exist anymore.");
              var problemDetails = new ValidationProblemDetails(context.ModelState)
              {
                  Status = StatusCodes.Status404NotFound
              };
              context.Result = new NotFoundObjectResult(problemDetails);
          }
       }

    }

}
