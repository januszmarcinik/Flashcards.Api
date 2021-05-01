using System;

namespace Flashcards.Application.Users
{
    public class JwtDto
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
