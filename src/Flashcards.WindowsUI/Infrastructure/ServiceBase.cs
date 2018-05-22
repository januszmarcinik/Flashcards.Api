using System;
using Flashcards.WindowsUI.Controls;
using Flashcards.WindowsUI.Models;

namespace Flashcards.WindowsUI.Infrastructure
{
    abstract class ServiceBase
    {
        protected string RestUrl(Topic topic)
            => $@"/topics/{topic}/categories";

        protected string RestUrl(Topic topic, Guid id)
            => $@"{RestUrl(topic)}/{id}";

        protected string RestUrl(Topic topic, string category)
            => $@"{RestUrl(topic)}/{category}/decks";

        protected string RestUrl(Topic topic, string category, Guid id)
            => $@"{RestUrl(topic, category)}/{id}";

        protected string RestUrl(Topic topic, string category, string deck)
            => $@"{RestUrl(topic, category)}/{deck}/cards";

        protected string RestUrl(Topic topic, string category, string deck, Guid id)
            => $@"{RestUrl(topic, category, deck)}/{id}";

        protected T Handle<T>(string url) where T : class, new()
        {
            using (var client = new FlashcardsHttpClient())
            {
                var response = client.Get<T>(url);
                if (response.IsSuccess)
                {
                    return response.Result;
                }
                else
                {
                    FlashcardsMessageBox.Error(response.ErrorMessage);
                    return new T();
                }
            }
        }

        protected bool Handle<T>(Func<ApiResponse<T>> action)
        {
            var response = action();
            if (response.IsSuccess)
            {
                return true;
            }
            else
            {
                FlashcardsMessageBox.Error(response.ErrorMessage);
                return false;
            }
        }
    }
}
