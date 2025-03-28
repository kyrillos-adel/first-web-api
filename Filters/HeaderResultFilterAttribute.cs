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
        context.HttpContext.Response.Headers.Append("AppName", "Lab1 App");
        
        // CORS headers to bypass CORS
        /*context.HttpContext.Response.Headers.Append("access-control-allow-credentials", "true");
        context.HttpContext.Response.Headers.Append("access-control-allow-methods", "*");
        context.HttpContext.Response.Headers.Append("Access-Control-Allow-Origin", "*");
        // access-control-allow-credentials: true
        // access-control-allow-methods: *
        // Access-Control-Allow-Origin: **/
        
        base.OnResultExecuting(context);
    }
}