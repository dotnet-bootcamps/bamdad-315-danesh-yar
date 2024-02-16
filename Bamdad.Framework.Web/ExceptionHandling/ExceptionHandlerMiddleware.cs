using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Bamdad.Framework.core.Exceptions;
using ValidationException = Bamdad.Framework.core.Exceptions.ValidationException;
using System.ComponentModel.Design;
using System.Xml.Linq;
using UAParser;

namespace Bamdad.Framework.Web.ExceptionHandling;
public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {

        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            await context.Response.WriteAsync($"Error :  {ex.Message}");
        }
        catch (Exception ex)
        {
            var frame = new StackTrace(ex, true)?.GetFrame(0);
            var errorCode = new Random().Next(100000, 999999);
            var uaParser = Parser.GetDefault().Parse(context.Request.Headers["User-Agent"].ToString());
            var pageRoute = context.Request.Headers["Page-Route"].ToString();
            using (_logger.BeginScope(new Dictionary<string, object?>
            {
                { "ErrorFilePath",  $"File : {frame?.GetFileName()} - Line  : {frame?.GetFileLineNumber()}" },
                       { "MethodPath", ex?.TargetSite?.DeclaringType?.FullName },
                       { "InnerException", ex?.InnerException?.Message },
                { "UserId", 0  },
                       { "CompanyId", 0 },
                       { "ErrorCode", errorCode.ToString() },
                       { "UserAgent", $"{uaParser?.Device} - {uaParser?.OS} - {uaParser?.UA}" },
                       { "PageRoute", pageRoute},
                       { "AdditionalData",""}
                   }))
            {
                _logger.LogError(ex, ex?.Message);
                
            }
            await context.Response.WriteAsync($"Error :  {ex.Message}");
        }


    }
}