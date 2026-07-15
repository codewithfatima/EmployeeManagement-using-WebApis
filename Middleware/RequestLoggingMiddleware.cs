using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Text.Json;


namespace StudentManagment.Middleware
{
    public class RequestLoggingMiddleware
    {
        public class GlobalExceptionMiddleware
        {
            private readonly RequestDelegate _next;

            public GlobalExceptionMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    var errorResponse = new
                    {
                        StatusCode = context.Response.StatusCode,
                        message = ex.Message,
                    };

                    var json = JsonSerializer.Serialize(errorResponse);
                    await context.Response.WriteAsync(json);
                }
            }

        }
    }
}
