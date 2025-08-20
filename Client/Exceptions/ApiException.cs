using System.Net;

namespace PoverkaWinForms.Exceptions;

public class ApiException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public ApiException(HttpStatusCode statusCode, string? message = null)
        : base(message ?? $"Ошибка HTTP {(int)statusCode}")
    {
        StatusCode = statusCode;
    }
}
