using System.Text.Json;
using MvcAyudAR.Models.Exceptions;
using MvcAyudAR.Services.DTOs;

namespace MvcAyudAR.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ExceptionNotFound ex)
        {
            await StatusMessage(context, 404, ex.Message, ex);
        }
        catch (ExceptionBadRequest ex)
        {
            await StatusMessage(context, 400, ex.Message, ex);
        }
        catch (ConflictException ex)
        {
            await StatusMessage(context, 409, ex.Message, ex);
        }
    }

    private async Task StatusMessage(HttpContext context, int statusCode, string message, Exception ex)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";
        _logger.LogError(ex,"Ocurrio un error");
        var response = new ErrorResponse
        {
            StatusCode = statusCode,
            Message = message
        };
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));

    }
}