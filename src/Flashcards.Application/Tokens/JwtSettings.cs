using Flashcards.Core;

namespace Flashcards.Application.Tokens
{
    public class JwtSettings : ISettings
    {
        public string Key { get; set; }
        public int ExpiryMinutes { get; set; }
        public string Issuer { get; set; }
    }
}
