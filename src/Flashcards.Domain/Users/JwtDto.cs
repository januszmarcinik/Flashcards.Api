using System;

namespace Flashcards.Domain.Users
{
    public class JwtDto
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
