using Flashcards.Core;

namespace Flashcards.Infrastructure.Settings
{
    public class JwtSettings : ISettings
    {
        public string Key { get; set; }
        public int ExpiryMinutes { get; set; }
        public string Issuer { get; set; }
    }
}
