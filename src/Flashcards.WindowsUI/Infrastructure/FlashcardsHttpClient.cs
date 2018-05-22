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
            LoadToken();
        }

        public void LoadToken()
        {
            if (Session.Jwt != null && Session.Jwt.Token.IsNotEmpty())
            {
                DefaultRequestHeaders.Add("Authorization", $"Bearer {Session.Jwt.Token}");
            }
        }

        public ApiResponse<T> Get<T>(string requestUri) 
            => GetAsync(GetRequestUri(requestUri)).GetApiResponse<T>();

        public ApiResponse<string> Get(string requestUri)
            => GetAsync(GetRequestUri(requestUri)).GetApiResponse<string>();

        public ApiResponse<T> Post<T>(string requestUri, object body)
            => PostAsync(GetRequestUri(requestUri), GetContent(body)).GetApiResponse<T>();

        public ApiResponse<string> Post(string requestUri, object body)
            => PostAsync(GetRequestUri(requestUri), GetContent(body)).GetApiResponse<string>();

        public ApiResponse<T> Put<T>(string requestUri, object body)
            => PutAsync(GetRequestUri(requestUri), GetContent(body)).GetApiResponse<T>();

        public ApiResponse<string> Put(string requestUri, object body)
            => PutAsync(GetRequestUri(requestUri), GetContent(body)).GetApiResponse<string>();

        public ApiResponse<T> Delete<T>(string requestUri)
            => DeleteAsync(GetRequestUri(requestUri)).GetApiResponse<T>();

        public ApiResponse<string> Delete(string requestUri)
            => DeleteAsync(GetRequestUri(requestUri)).GetApiResponse<string>();

        private string GetRequestUri(string requestUri)
            => $"{ApiUrl}{requestUri}";

        private HttpContent GetContent(object body)
            => new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
    }
}
