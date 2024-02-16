using Bamdad.Framework.core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Bamdad.Framework.Web.ApiResponses;
public class ApiResponse
{
    public bool Succeeded { get; set; }
    public ApiResponseStatusCode StatusCode { get; set; }
    public string? Message { get; set; }
    public int ErrorCode { get; set; }
    public bool IsShowErrorCode { get; set; } = true;

    public ApiResponse(bool succeeded, ApiResponseStatusCode statusCode, string? message = null, bool isShowErrorCode = true)
    {
        Succeeded = succeeded;
        StatusCode = statusCode;
        Message = message ?? statusCode.ToString();
        IsShowErrorCode = isShowErrorCode;
    }
    public ApiResponse(bool succeeded, ApiResponseStatusCode statusCode, int errorCode, string? message = null, bool isShowErrorCode = true)
    {
        Succeeded = succeeded;
        StatusCode = statusCode;
        ErrorCode = errorCode;
        Message = message ?? statusCode.ToString();
        IsShowErrorCode = isShowErrorCode;
    }

    #region Implicit operators

    public static implicit operator ApiResponse(OkResult result)
    {
        return new ApiResponse(true, ApiResponseStatusCode.Success);
    }

    public static implicit operator ApiResponse(BadRequestResult result)
    {
        return new ApiResponse(false, ApiResponseStatusCode.BadRequest);
    }

    public static implicit operator ApiResponse(BadRequestObjectResult result)
    {
        var message = result?.Value?.ToString();
        if (result?.Value is SerializableError errors)
        {
            var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
            message = string.Join(" | ", errorMessages);
        }
        return new ApiResponse(false, ApiResponseStatusCode.BadRequest, message);
    }

    public static implicit operator ApiResponse(ContentResult result)
    {
        return new ApiResponse(true, ApiResponseStatusCode.Success, result.Content);
    }

    public static implicit operator ApiResponse(NotFoundResult result)
    {
        return new ApiResponse(false, ApiResponseStatusCode.NotFound);
    }

    public static implicit operator ApiResponse(ForbidResult result)
    {
        return new ApiResponse(false, ApiResponseStatusCode.Forbidden);
    }

    public static implicit operator ApiResponse(UnauthorizedResult result)
    {
        return new ApiResponse(false, ApiResponseStatusCode.UnAuthorized);
    }

    public static implicit operator ApiResponse(UnauthorizedObjectResult result)
    {
        var message = result?.Value?.ToString();
        if (result?.Value is SerializableError errors)
        {
            var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
            message = string.Join(" | ", errorMessages);
        }
        return new ApiResponse(false, ApiResponseStatusCode.UnAuthorized, message);
    }

    #endregion
}
