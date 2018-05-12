using System.Collections.Generic;
using System.Windows.Forms;
using Flashcards.WindowsUI.Infrastructure;
using Flashcards.WindowsUI.Models;

namespace Flashcards.WindowsUI.Services
{
    class CategoriesService : ServiceBase
    {
        public List<Category> GetAll(Topic topic)
        {
            using (var client = new FlashcardsHttpClient())
            {
                var response = client.Get<List<Category>>(RestUrl(topic));
                if (response.IsSuccess)
                {
                    return response.Result;
                }
                else
                {
                    MessageBox.Show(response.Message);
                    return new List<Category>();
                }
            }
        }
    }
}
