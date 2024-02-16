using Bamdad.Framework.core.Enums;
using Microsoft.AspNetCore.Mvc;
namespace Bamdad.Framework.Web.ApiResponses;
public sealed class ApiResponse<TData> where TData : class
{
    public TData? Data { get; set; }
    public bool Succeed { get; set; }
    public ApiResponseStatusCode StatusCode { get; set; }
    public string? Message { get; set; }

    public ApiResponse(bool succeed, ApiResponseStatusCode statusCode, TData? data, string? message = null)
    {
        Data = data;
        Succeed = succeed;
        StatusCode = statusCode;
        Message = message;
    }

    #region Implicit Operators

    public static implicit operator ApiResponse<TData>(TData data)
    {
        return new ApiResponse<TData>(true, ApiResponseStatusCode.Success, data);
    }

    public static implicit operator ApiResponse<TData>(OkResult result)
    {
        return new ApiResponse<TData>(true, ApiResponseStatusCode.Success, null);
    }

    public static implicit operator ApiResponse<TData>(OkObjectResult result)
    {
        return new ApiResponse<TData>(true, ApiResponseStatusCode.Success, (TData?)result.Value);
    }

    public static implicit operator ApiResponse<TData>(BadRequestResult result)
    {
        return new ApiResponse<TData>(false, ApiResponseStatusCode.BadRequest, null);
    }

    public static implicit operator ApiResponse<TData>(BadRequestObjectResult result)
    {
        var message = result?.Value?.ToString();
        if (result?.Value is SerializableError errors)
        {
            var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
            message = string.Join(" | ", errorMessages);
        }
        return new ApiResponse<TData>(false, ApiResponseStatusCode.BadRequest, null, message);
    }

    public static implicit operator ApiResponse<TData>(ContentResult result)
    {
        return new ApiResponse<TData>(true, ApiResponseStatusCode.Success, null, result.Content);
    }

    public static implicit operator ApiResponse<TData>(NotFoundResult result)
    {
        return new ApiResponse<TData>(false, ApiResponseStatusCode.NotFound, null);
    }

    public static implicit operator ApiResponse<TData>(NotFoundObjectResult result)
    {
        return new ApiResponse<TData>(false, ApiResponseStatusCode.NotFound, (TData?)result.Value);
    }

    #endregion
}