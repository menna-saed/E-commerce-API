using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace Ecommerce.API.Middleware;

public class GlobalExceptionHandler(IProblemDetailsService problemDetailsService ,ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
  


    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var isValidationFailure = exception is ValidationException;
        var statusCode = isValidationFailure
            ? StatusCodes.Status400BadRequest
            : StatusCodes.Status500InternalServerError;

        logger.LogError(exception, "Request failed with status code {StatusCode}", statusCode);
        httpContext.Response.StatusCode = statusCode;

        var problemDetailsContextontext = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = new ProblemDetails()
            {
                Status = statusCode,
                Title = isValidationFailure ? "Validation failed" : "Unhandled exception occurred",
                Detail = isValidationFailure ? exception.Message : "An unhandled exception occurred"
            }
        };

        await problemDetailsService.TryWriteAsync(problemDetailsContextontext);

        return true;
    }
}
