using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flashcards.WindowsUI.Infrastructure;
using Newtonsoft.Json;

namespace Flashcards.WindowsUI.Extensions
{
    static class HttpResponseExtensions
    {
        public static ApiResponse<T> GetApiResponse<T>(this Task<HttpResponseMessage> task)
        {
            var response = task.GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync()
                .GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                var result = typeof(T) == typeof(string)
                    ? (T)Convert.ChangeType(content, typeof(T))
                    : JsonConvert.DeserializeObject<T>(content);

                return ApiResponse<T>.Success(result);
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ApiException>(content);
                return ApiResponse<T>.Error($"{result.ErrorCode}: {result.Message}");
            }
        }
    }
}
