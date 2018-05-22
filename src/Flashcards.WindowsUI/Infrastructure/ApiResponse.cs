namespace Flashcards.WindowsUI.Infrastructure
{
    class ApiResponse<T>
    {
        public T Result { get; }
        public bool IsSuccess { get; }
        public string ErrorMessage { get; }

        private ApiResponse(bool isSuccess, T result, string errorMessage)
        {
            IsSuccess = isSuccess;
            Result = result;
            ErrorMessage = errorMessage;
        }

        public static ApiResponse<T> Success(T result)
            => new ApiResponse<T>(true, result, string.Empty);

        public static ApiResponse<T> Error(string errorMessage)
            => new ApiResponse<T>(false, default(T), errorMessage);
    }
}
