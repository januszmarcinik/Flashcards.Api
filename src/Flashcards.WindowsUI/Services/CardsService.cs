using System;
using System.Collections.Generic;
using Flashcards.WindowsUI.Infrastructure;
using Flashcards.WindowsUI.Models;

namespace Flashcards.WindowsUI.Services
{
    class CardsService : ServiceBase
    {
        public List<Card> GetAll(Topic topic, string category, string deck)
            => Handle<List<Card>>(RestUrl(topic, category, deck));

        public Card GetById(Topic topic, string category, string deck, Guid id)
            => Handle<Card>(RestUrl(topic, category, deck, id));

        public bool Add(Topic topic, string category, string deck, Card card)
            => Handle(() =>
            {
                using (var client = new FlashcardsHttpClient())
                {
                    client.Post(RestUrl(topic, category, deck), card);
                }
            });

        public bool Edit(Topic topic, string category, string deck, Card card)
            => Handle(() =>
            {
                using (var client = new FlashcardsHttpClient())
                {
                    client.Put(RestUrl(topic, category, deck), card);
                }
            });

        public bool Delete(Topic topic, string category, string deck, Guid id)
            => Handle(() =>
            {
                using (var client = new FlashcardsHttpClient())
                {
                    client.Delete(RestUrl(topic, category, deck, id));
                }
            });
    }
}
