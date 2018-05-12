using System.Configuration;
using System.Net.Http;
using System.Text;
using Flashcards.WindowsUI.Extensions;
using Newtonsoft.Json;

namespace Flashcards.WindowsUI.Infrastructure
{
    class FlashcardsHttpClient : HttpClient
    {
        private string ApiUrl 
            => ConfigurationManager.AppSettings["ApiUrl"];

        public FlashcardsHttpClient()
        {
            if (Session.Jwt != null && Session.Jwt.Token.IsNotEmpty())
            {
                DefaultRequestHeaders.Add("Authorization", $"Bearer {Session.Jwt.Token}");
            }
        }

        public ApiResponse<T> Get<T>(string requestUri)
        {
            var response = GetAsync(GetRequestUri(requestUri))
                .GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync()
                .GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<T>(content);
                return ApiResponse<T>.Success(result);
            }
            else
            {
                return ApiResponse<T>.Error(content, response.StatusCode);
            }
        }

        public ApiResponse<T> Post<T>(string requestUri, object body)
        {
            var response = PostAsync(GetRequestUri(requestUri), GetContent(body))
                .GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync()
                .GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<T>(content);
                return ApiResponse<T>.Success(result);
            }
            else
            {
                return ApiResponse<T>.Error(content, response.StatusCode);
            }
        }

        private string GetRequestUri(string requestUri)
        {
            return $"{ApiUrl}{requestUri}";
        }

        private HttpContent GetContent(object body)
        {
            return new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        }
    }
}
