
using System.Diagnostics;

namespace WebApi.Middlewares;

public class CustomExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var watch = Stopwatch.StartNew();
        string message = "[Request] HTTP " + context.Request.Method + " " + context.Request.Path;
        Console.WriteLine(message);
        await _next(context);
        watch.Stop();
        message = "[Response] HTTP " + context.Request.Method + " " + context.Request.Path + "responded" +
                  context.Response.StatusCode + " in " +watch.Elapsed.TotalMilliseconds  +"ms "   ;
    }
}


public static class CustomExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionMiddleware>();
    }
}





