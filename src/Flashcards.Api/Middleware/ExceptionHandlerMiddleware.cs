using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Flashcards.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _request;

        public ExceptionHandlerMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
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
}
