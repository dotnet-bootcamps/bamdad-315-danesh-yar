using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamdad.Framework.Web.ExceptionHandling;
public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder Use_ExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
