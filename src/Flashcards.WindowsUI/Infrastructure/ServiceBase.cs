using System;
using System.Windows.Forms;
using Flashcards.WindowsUI.Models;

namespace Flashcards.WindowsUI.Infrastructure
{
    public abstract class ServiceBase
    {
        protected string RestUrl(Topic topic)
        {
            return $@"/topics/{topic}/categories";
        }

        protected string RestUrl(Topic topic, Guid id)
        {
            return $@"{RestUrl(topic)}/{id}";
        }

        protected string RestUrl(Topic topic, string category)
        {
            return $@"{RestUrl(topic)}/{category}/decks";
        }

        protected string RestUrl(Topic topic, string category, Guid id)
        {
            return $@"{RestUrl(topic, category)}/{id}";
        }

        protected string RestUrl(Topic topic, string category, string deck)
        {
            return $@"{RestUrl(topic, category)}/{deck}/cards";
        }

        protected string RestUrl(Topic topic, string category, string deck, Guid id)
        {
            return $@"{RestUrl(topic, category, deck)}/{id}";
        }

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
                    MessageBox.Show(response.Message);
                    return new T();
                }
            }
        }

        protected bool Handle(Action action)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
