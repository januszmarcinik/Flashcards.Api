using System.Collections.Generic;
using System.Windows.Forms;
using Flashcards.WindowsUI.Infrastructure;
using Flashcards.WindowsUI.Models;

namespace Flashcards.WindowsUI.Services
{
    class DecksService : ServiceBase
    {
        public List<Deck> GetAll(Topic topic, string category)
        {
            using (var client = new FlashcardsHttpClient())
            {
                var response = client.Get<List<Deck>>(RestUrl(topic, category));
                if (response.IsSuccess)
                {
                    return response.Result;
                }
                else
                {
                    MessageBox.Show(response.Message);
                    return new List<Deck>();
                }
            }
        }
    }
}
