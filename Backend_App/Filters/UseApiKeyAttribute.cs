using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Backend_App.Filters;


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class UseApiKeyAttribute : Attribute, IAsyncActionFilter
{
    private const string ApiKeyHeaderName = "ApiKey";
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var potentialApiKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }
            
        var config = context.HttpContext.RequestServices.GetService<IConfiguration>();
        var apiKey = config!.GetValue<string>(ApiKeyHeaderName);

        if(!apiKey!.Equals(apiKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        await next();
    }
}