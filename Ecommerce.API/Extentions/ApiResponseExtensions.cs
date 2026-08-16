using Ecommerce.API.Models;
using Ecommerce.Domain.common;
using Ecommerce.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Extentions;

public static class ApiResponseExtensions
{
    public static IResult ApiOk<T>(
        this HttpContext context,
        
        T data,
        string? message = null,
        PaginationMeta? pagination = null)
    {
        var response = ApiResponse<T>.Ok(
            data,
            context.TraceIdentifier,
            message,
            pagination);

        //200 ok
        return Results.Ok(response);
    }

    public static IResult ApiProblem(this Result results , HttpContext httpContext)
    {
        var statusCode = results.Error.Type switch
        {
            ErrorType.Conflict =>  StatusCodes.Status409Conflict,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };

        var title = results.Error.Type switch
        {
            ErrorType.Validation => "Validation Failed",
            ErrorType.NotFound => "Not Found",
            ErrorType.Conflict => "Conflict",
            ErrorType.Unauthorized => "Unauthorized",
            ErrorType.Forbidden => "Forbidden",
            _ => "Internal Server Error"
        };
        var problem = new Dictionary<string, object>
        {
            ["type"] = "",
            ["title"] = title,
            ["status"] = statusCode

        };
        if (results.Error.Type == ErrorType.Validation)
        {
            problem["error"] = new Dictionary<string, string[]>()
            {
        [results.Error. Code] = [results.Error.Description]
            };
        }
        else
        {
            problem["details"] = results.Error.Description;

        } ;
        problem["traceId"] = httpContext.TraceIdentifier;
        
        return Results.Json(problem, statusCode: statusCode);
    }
}