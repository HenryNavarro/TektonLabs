using Microsoft.AspNetCore.Mvc;
using TektonLabs.Challenge.Application.Exceptions;

namespace TektonLabs.Challenge.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var exceptionDetails = GetExceptionDetails(exception);
            var problemDetails = new ProblemDetails
            {
                Status = exceptionDetails.Status,
                Type = exceptionDetails.Type,
                Title = exceptionDetails.Title,
                Detail = exceptionDetails.Detail
            };

            if (exceptionDetails.Errors is not null)
                problemDetails.Extensions["errors"] = exceptionDetails.Errors;

            context.Response.StatusCode = exceptionDetails.Status;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

    private static ExceptionDetails GetExceptionDetails(Exception exception)
    {
        ExceptionDetails exceptionDetails;
        switch (exception)
        {
            case ValidationException validationException:
                exceptionDetails = new ExceptionDetails(
                StatusCodes.Status400BadRequest,
                "ValidationFailure",
                "Validacion de Error",
                "han ocurrido uno o mas errores de validacion",
                validationException.Errors
            );
                break;

            default:
                exceptionDetails = new ExceptionDetails(
                StatusCodes.Status500InternalServerError,
                "ServerError",
                "Error de Servidor",
                "Un inesperado error a ocurrido en la App",
                null
            );
                break;
        }
        return exceptionDetails;
    }
}


internal record ExceptionDetails(
    int Status,
    string Type,
    string Title,
    string Detail,
    IEnumerable<object>? Errors
);
