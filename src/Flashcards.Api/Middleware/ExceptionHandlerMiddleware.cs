using Flashcards.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NLog;
using System;
using System.Net;
using System.Threading.Tasks;
using Flashcards.Core.Extensions;

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
            var errorCode = nameof(HttpStatusCode.InternalServerError);
            var httpStatusCode = HttpStatusCode.InternalServerError;
            var message = ex.Message;

            if (ex is UnauthorizedAccessException)
            {
                httpStatusCode = HttpStatusCode.Unauthorized;
                errorCode = nameof(HttpStatusCode.Unauthorized);
            }
            else if (ex is FlashcardsException)
            {
                var flashcardsException = ex as FlashcardsException;
                httpStatusCode = flashcardsException.ErrorCode.HttpStatusCode;
                errorCode = flashcardsException.ErrorCode.Message;
                message = flashcardsException.Message.IsEmpty() ? errorCode : flashcardsException.Message;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;
            var responseBody = JsonConvert.SerializeObject(new { errorCode, message });

            return context.Response.WriteAsync(responseBody);
        }
    }
}
