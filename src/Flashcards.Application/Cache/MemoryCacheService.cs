using System;
using Microsoft.Extensions.Caching.Memory;

namespace Flashcards.Application.Cache
{
    internal class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(string key)
            => _memoryCache.Get<T>(key);

        public void Set(string key, object value, TimeSpan expirationTime)
            => _memoryCache.Set(key, value, expirationTime);

        public void Remove(string key)
            => _memoryCache.Remove(key);
    }
}
