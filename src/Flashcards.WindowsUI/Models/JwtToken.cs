using System;

namespace Flashcards.WindowsUI.Models
{
    class JwtToken
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
