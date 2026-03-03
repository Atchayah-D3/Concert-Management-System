using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi;

namespace WebApplication1.Middleware
{
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
            catch(Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new
                {
                    success = false,
                    statusCode = StatusCodes.Status500InternalServerError,
                    message = e.Message
                }); 
            }
        }
    }
    public static class ExceptionHandlingExtension
    {
        public static IApplicationBuilder UseExceptionHandling(
           this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}