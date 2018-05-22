using System;
using System.Collections.Generic;
using Flashcards.WindowsUI.Infrastructure;
using Flashcards.WindowsUI.Models;

namespace Flashcards.WindowsUI.Services
{
    class CategoriesService : ServiceBase
    {
        public List<Category> GetAll(Topic topic)
            => Handle<List<Category>>(RestUrl(topic));

        public bool Add(Topic topic, Category category)
            => Handle(() =>
            {
                using (var client = new FlashcardsHttpClient())
                {
                    return client.Post(RestUrl(topic), category);
                }
            });

        public bool Edit(Topic topic, Category category)
            => Handle(() =>
            {
                using (var client = new FlashcardsHttpClient())
                {
                    return client.Put(RestUrl(topic), category);
                }
            });

        public bool Delete(Topic topic, Guid id)
            => Handle(() =>
            {
                using (var client = new FlashcardsHttpClient())
                {
                    return client.Delete(RestUrl(topic, id));
                }
            });
    }
}
