using System.Net;
using Lab.WebApi.Core.Exceptions;

namespace Lab.Customers.Api.Extensions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (CustomHttpResponseMessage ex)
        {
            HandleException(context, ex.StatusCode);
        }
    }

    private static void HandleException(HttpContext context, HttpStatusCode statusCode)
    {
        context.Response.StatusCode = (int)statusCode;
    }
}