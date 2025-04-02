using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab1.Filters;

public class ValidateUserFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.HttpContext.User.FindFirst("StudentId")?.Value != context.RouteData.Values["id"]?.ToString())
        {
            context.Result = new UnauthorizedResult();
        }
    }
}