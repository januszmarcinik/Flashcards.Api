using Flashcards.Core;

namespace Flashcards.Infrastructure.Settings
{
    public class QueueSettings : ISettings
    {
        public string HostName { get; set; }
        public string QueueName { get; set; }
    }
}