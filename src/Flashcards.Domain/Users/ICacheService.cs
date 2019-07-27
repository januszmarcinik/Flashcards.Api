using System;

namespace Flashcards.Domain.Users
{
    public interface ICacheService
    {
        T Get<T>(string key);

        void Set(string key, object value, TimeSpan expirationTime);
    }
}
