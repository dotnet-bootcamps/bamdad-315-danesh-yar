using Bamdad.Framework.core.Enums;
using Newtonsoft.Json;
using System.Net;

namespace Bamdad.Framework.core.Exceptions;
public class ValidationException : ApplicationException
{
    public HttpStatusCode HttpStatusCode { get; set; }
    public ApiResponseStatusCode ApiStatusCode { get; set; }
    public string? AdditionalData { get; set; }
    public ValidationException(string message) : this(ApiResponseStatusCode.ServerError, message, HttpStatusCode.InternalServerError)
    {
    }

    public ValidationException(ApiResponseStatusCode statusCode, string message) : this(statusCode, message, HttpStatusCode.InternalServerError)
    {
    }

    public ValidationException(HttpStatusCode statusCode, string message) : this(ApiResponseStatusCode.ServerError, message, statusCode)
    {
    }

    public ValidationException(string message, object additionalData) : this(ApiResponseStatusCode.ServerError, message, additionalData)
    {
    }

    public ValidationException(ApiResponseStatusCode statusCode, string message, object additionalData) : this(statusCode, message, HttpStatusCode.InternalServerError, additionalData)
    {
    }

    public ValidationException(ApiResponseStatusCode statusCode, string message, HttpStatusCode httpStatusCode) : this(statusCode, message, httpStatusCode, null)
    {
    }

    public ValidationException(ApiResponseStatusCode statusCode, string message, HttpStatusCode httpStatusCode, object additionalData) : this(statusCode, message, httpStatusCode, null, additionalData)
    {
    }

    public ValidationException(string message, System.Exception exception) : this(ApiResponseStatusCode.ServerError, message, exception)
    {
    }

    public ValidationException(string message, System.Exception exception, object additionalData) : this(ApiResponseStatusCode.ServerError, message, exception, additionalData)
    {
    }

    public ValidationException(ApiResponseStatusCode statusCode, string message, System.Exception exception) : this(statusCode, message, HttpStatusCode.InternalServerError, exception)
    {
    }

    public ValidationException(ApiResponseStatusCode statusCode, string message, System.Exception exception, object additionalData) : this(statusCode, message, HttpStatusCode.InternalServerError, exception, additionalData)
    {
    }

    public ValidationException(ApiResponseStatusCode statusCode, string message, HttpStatusCode httpStatusCode, System.Exception? exception) : this(statusCode, message, httpStatusCode, exception, null)
    {
    }

    public ValidationException(ApiResponseStatusCode statusCode, string message, HttpStatusCode httpStatusCode, System.Exception? exception, object? additionalData) : base(message, exception)
    {
        this.ApiStatusCode = statusCode;
        this.HttpStatusCode = httpStatusCode;
        this.AdditionalData = JsonConvert.SerializeObject(additionalData);
    }
}
