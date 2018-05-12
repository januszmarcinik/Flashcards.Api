using System.Net;

namespace Flashcards.WindowsUI.Infrastructure
{
    class ApiResponse<T>
    {
        public T Result { get; private set; }
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public HttpStatusCode HttpStatusCode { get; private set; }

        public static ApiResponse<T> Success(T result)
        {
            return new ApiResponse<T>()
            {
                Result = result,
                IsSuccess = true,
                Message = string.Empty,
                HttpStatusCode = HttpStatusCode.OK
            };
        }

        public static ApiResponse<T> Error(string message)
        {
            return new ApiResponse<T>()
            {
                Result = default(T),
                IsSuccess = false,
                Message = message,
                HttpStatusCode = HttpStatusCode.BadRequest
            };
        }

        public static ApiResponse<T> Error(string message, HttpStatusCode httpStatusCode)
        {
            return new ApiResponse<T>()
            {
                Result = default(T),
                IsSuccess = false,
                Message = message,
                HttpStatusCode = httpStatusCode
            };
        }
    }
}
