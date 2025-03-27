using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab1.Filters;

public class ValidateLocationFilterAttribute : ActionFilterAttribute
{
    private readonly string validLocations;
    private readonly string[] validLocationsArray;
    
    
    public ValidateLocationFilterAttribute(string validLocations)
    {
        this.validLocations = validLocations;
        this.validLocationsArray = validLocations.Split(",");
    }
    
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionArguments.TryGetValue("department", out var department))
        {
            Department dept = department as Department; 
            if (!validLocationsArray.Contains(dept.Location))
            {
                context.Result = new BadRequestObjectResult($"Allowed locations are {validLocations}");
            }
        }
    }
}