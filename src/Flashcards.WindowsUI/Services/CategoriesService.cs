using System.Collections.Generic;
using System.Windows.Forms;
using Flashcards.WindowsUI.Infrastructure;
using Flashcards.WindowsUI.Models;

namespace Flashcards.WindowsUI.Services
{
    class CategoriesService : ServiceBase
    {
        public List<Category> GetAll(Topic topic)
            => Handle<List<Category>>(RestUrl(topic));

        public void Add(Topic topic, Category category)
        {
            using (var client = new FlashcardsHttpClient())
            {
                client.Post(RestUrl(topic), category);
            }
        }
    }
}
