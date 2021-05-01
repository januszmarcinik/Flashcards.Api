using Flashcards.Core;

namespace Flashcards.Infrastructure.Settings
{
    public class AppSettings : ISettings
    {
        public string Name { get; set; }
        public bool IsCloud { get; set; }
    }
}
