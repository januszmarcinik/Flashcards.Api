using System;

namespace Flashcards.Domain
{
    public interface ICacheService
    {
        T Get<T>(string key);

        void Set(string key, object value, TimeSpan expirationTime);

        void Remove(string key);
    }
}
