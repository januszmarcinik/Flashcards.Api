using System;

namespace Flashcards.Infrastructure.Dto.Tokens
{
    public class JwtDto
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
