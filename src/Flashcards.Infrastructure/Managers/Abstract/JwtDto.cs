using System;

namespace Flashcards.Infrastructure.Managers.Abstract
{
    public class JwtDto
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
