using System;
using Flashcards.Domain.Users;

namespace Flashcards.Domain.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this ICacheService cache, Guid tokenId, JwtDto jwt)
            => cache.Set(GetJwtKey(tokenId), jwt, TimeSpan.FromSeconds(5));

        public static JwtDto GetJwt(this ICacheService cache, Guid tokenId)
            => cache.Get<JwtDto>(GetJwtKey(tokenId));

        private static string GetJwtKey(Guid tokenId)
            => $"jwt-{tokenId}";
    }
}
