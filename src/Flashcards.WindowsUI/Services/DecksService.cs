using System;
using System.Collections.Generic;
using Flashcards.WindowsUI.Infrastructure;
using Flashcards.WindowsUI.Models;

namespace Flashcards.WindowsUI.Services
{
    class DecksService : ServiceBase
    {
        public List<Deck> GetAll(Topic topic, string category)
            => Handle<List<Deck>>(RestUrl(topic, category));

        public bool Add(Topic topic, string category, Deck deck)
            => Handle(() =>
            {
                using (var client = new FlashcardsHttpClient())
                {
                    return client.Post(RestUrl(topic, category), deck);
                }
            });

        public bool Edit(Topic topic, string category, Deck deck)
            => Handle(() =>
            {
                using (var client = new FlashcardsHttpClient())
                {
                    return client.Put(RestUrl(topic, category), deck);
                }
            });

        public bool Delete(Topic topic, string category, Guid id)
            => Handle(() =>
            {
                using (var client = new FlashcardsHttpClient())
                {
                    return client.Delete(RestUrl(topic, category, id));
                }
            });
    }
}
