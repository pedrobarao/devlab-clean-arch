using System.Net;

namespace Lab.WebApi.Core.Exceptions;

public class CustomHttpResponseMessage : Exception
{
    public HttpStatusCode StatusCode;

    public CustomHttpResponseMessage()
    {
    }

    public CustomHttpResponseMessage(string message, Exception innerException) : base(message, innerException)
    {
    }

    public CustomHttpResponseMessage(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
    }
}