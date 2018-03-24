using Flashcards.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NLog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Flashcards.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _request;
        private readonly ILogger _logger;

        public ExceptionHandlerMiddleware(RequestDelegate request, ILogger logger)
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
                _logger.Error(ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.BadRequest;
            var message = ex.Message;

            if (ex is UnauthorizedAccessException)
            {
                code = HttpStatusCode.Unauthorized;
            }
            else if (ex is FlashcardsException)
            {
                var errorCode = (ex as FlashcardsException).ErrorCode;
                code = errorCode.HttpStatusCode;
                message = $"{errorCode.Message}: '{ex.Message}'";
            }
            else
            {
                code = HttpStatusCode.InternalServerError;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            var responseBody = JsonConvert.SerializeObject(new { code, message });

            return context.Response.WriteAsync(responseBody);
        }
    }
}
