using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Application.Exceptions;
using ShoppingList.Domain.Exceptions;

namespace ShoppingList.API.Common.ExceptionHandlers;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var (statusCode, title) = exception switch
        {
            DomainException => (HttpStatusCode.BadRequest, "Falha de validação do domínio"),
            NotFoundException => (HttpStatusCode.NotFound, "Recurso não encontrado"),
            _ => (HttpStatusCode.InternalServerError, "Erro interno"),
        };

        httpContext.Response.StatusCode = (int)statusCode;

        await httpContext.Response.WriteAsJsonAsync(
            new ProblemDetails
            {
                Status = (int)statusCode,
                Title = title,
                Detail = exception.Message,
                Type = $"https://httpstatuses.com/{(int)statusCode}",
            },
            cancellationToken);

        return true;
    }
}