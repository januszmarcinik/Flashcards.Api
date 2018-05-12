using System.Collections.Generic;
using Flashcards.WindowsUI.Infrastructure;
using Flashcards.WindowsUI.Models;

namespace Flashcards.WindowsUI.Services
{
    class CardsService : ServiceBase
    {
        public List<Card> GetAll(Topic topic, string category, string deck)
            => Handle<List<Card>>(RestUrl(topic, category, deck));
    }
}
