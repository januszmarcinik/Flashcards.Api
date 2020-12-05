using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace Flashcards.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _request;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate request, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _request = request;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message); 
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var errorCode = nameof(HttpStatusCode.InternalServerError);
            var httpStatusCode = HttpStatusCode.InternalServerError;
            var message = ex.Message;

            if (ex is UnauthorizedAccessException)
            {
                httpStatusCode = HttpStatusCode.Unauthorized;
                errorCode = nameof(HttpStatusCode.Unauthorized);
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;
            var responseBody = JsonConvert.SerializeObject(new { errorCode, message });

            return context.Response.WriteAsync(responseBody);
        }
    }
    
    internal static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder app) =>
            app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
