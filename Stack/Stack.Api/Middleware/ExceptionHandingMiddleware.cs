using Microsoft.AspNetCore.Mvc;
using Stack.Application.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Stack.Api.Middleware;

public class ExceptionHandingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandingMiddleware> _logger;

    public ExceptionHandingMiddleware(ILogger<ExceptionHandingMiddleware> logger, RequestDelegate next)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Exception occurred: {exception.Message}", exception.Message);

            var exceptionDetails = GetExceptionDetails(exception);

            var problemDetails = new ProblemDetails
            {
                Status = exceptionDetails.Status,
                Type = exceptionDetails.Type,
                Title = exceptionDetails.Title,
                Detail = exceptionDetails.Message
            };


            context.Response.StatusCode = exceptionDetails.Status;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

    private static ExceptionDetails GetExceptionDetails(Exception exception)
    {
        return exception switch
        {
            NotFoundException validationException => new ExceptionDetails(
                StatusCodes.Status404NotFound,
                "ValidationFailure",
                "Validation error",
                validationException.Message),
            _ => new ExceptionDetails(
               StatusCodes.Status500InternalServerError,
               "ServerError",
               "Server error",
               null)
        };
    }

    internal record ExceptionDetails(
        int Status,
        string Type,
        string Title,
        string Message);
}
