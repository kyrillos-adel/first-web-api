// using System.Configuration;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab1.Filters;

public class HeaderResultFilterAttribute : ResultFilterAttribute
{
    /*private readonly IConfiguration configuration;
    public HeaderResultFilterAttribute(IConfiguration configuration)
    {
        this.configuration = configuration;
    }*/

    public override void OnResultExecuting(ResultExecutingContext context)
    {
        // var config = context.HttpContext.RequestServices.GetService(typeof(Configuration)) as Configuration;
        
        context.HttpContext.Response.Headers.Append("AppName", "Lab1 App"/*configuration["AppName"]*/);
        base.OnResultExecuting(context);
    }
}