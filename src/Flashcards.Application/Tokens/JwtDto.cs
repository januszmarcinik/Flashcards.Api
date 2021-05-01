using System;

namespace Flashcards.Application.Tokens
{
    public class JwtDto
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
