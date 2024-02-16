using Microsoft.AspNetCore.Mvc.Filters;

namespace App.EndPoint.Ticketing.API.Attributes;

public class ApiKeyAuthorizeAttribute : Attribute, IAsyncActionFilter
{
    private const string APIKEYNAME = "ApiKey";
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            throw new Exception();

        var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

        var apiKey = appSettings.GetSection(APIKEYNAME);

        if (!(apiKey.Value == extractedApiKey))
            throw new Exception();

        await next();
    }
}

