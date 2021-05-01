using System;

namespace Flashcards.Application
{
    public interface ICacheService
    {
        T Get<T>(string key);

        void Set(string key, object value, TimeSpan expirationTime);

        void Remove(string key);
    }
}
