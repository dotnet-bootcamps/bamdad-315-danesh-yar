using Bamdad.Framework.core.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Bamdad.Framework.Web.ApiResponses;
public class ApiResponseFilterAttribute : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is OkObjectResult okObjectResult)
        {
            var apiResult = new ApiResponse<object>(true, ApiResponseStatusCode.Success, okObjectResult.Value);
            context.Result = new JsonResult(apiResult) { StatusCode = okObjectResult.StatusCode };
        }
        else if (context.Result is OkResult okResult)
        {
            var apiResult = new ApiResponse(true, ApiResponseStatusCode.Success);
            context.Result = new JsonResult(apiResult) { StatusCode = okResult.StatusCode };
        }
        else if (context.Result is BadRequestResult badRequestResult)
        {
            var apiResult = new ApiResponse(false, ApiResponseStatusCode.BadRequest);
            context.Result = new JsonResult(apiResult) { StatusCode = badRequestResult.StatusCode };
        }
        else if (context.Result is BadRequestObjectResult badRequestObjectResult)
        {
            string message = "";
            switch (badRequestObjectResult.Value)
            {
                case ValidationProblemDetails validation:
                    {
                        var errorMessages = validation.Errors.SelectMany(p => (string[])p.Value).Distinct();
                        message = string.Join(" | ", errorMessages);
                        break;
                    }
                case SerializableError errors:
                    {
                        var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                        message = string.Join(" | ", errorMessages);
                        break;
                    }
            }

            var apiResult = new ApiResponse(false, ApiResponseStatusCode.BadRequest, message);
            context.Result = new JsonResult(apiResult) { StatusCode = badRequestObjectResult.StatusCode };
        }
        else if (context.Result is ContentResult contentResult)
        {
            var apiResult = new ApiResponse(true, ApiResponseStatusCode.Success, contentResult.Content);
            context.Result = new JsonResult(apiResult) { StatusCode = contentResult.StatusCode };
        }
        else if (context.Result is NotFoundResult notFoundResult)
        {
            var apiResult = new ApiResponse(false, ApiResponseStatusCode.NotFound);
            context.Result = new JsonResult(apiResult) { StatusCode = notFoundResult.StatusCode };
        }
        else if (context.Result is NotFoundObjectResult notFoundObjectResult)
        {
            var apiResult = new ApiResponse<object>(false, ApiResponseStatusCode.NotFound, notFoundObjectResult.Value);
            context.Result = new JsonResult(apiResult) { StatusCode = notFoundObjectResult.StatusCode };
        }
        else if (context.Result is ObjectResult objectResult && objectResult.StatusCode == null
            && !(objectResult.Value is ApiResponse))
        {
            var apiResult = new ApiResponse<object>(true, ApiResponseStatusCode.Success, objectResult.Value);
            context.Result = new JsonResult(apiResult) { StatusCode = objectResult.StatusCode };
        }
        base.OnResultExecuting(context);
    }
}
