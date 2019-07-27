using System;

namespace Flashcards.Domain.Services
{
    public class JwtDto
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
