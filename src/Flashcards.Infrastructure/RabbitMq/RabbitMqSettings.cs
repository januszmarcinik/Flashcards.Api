using Flashcards.Core;

namespace Flashcards.Infrastructure.RabbitMq
{
    public class RabbitMqSettings : ISettings
    {
        public string HostName { get; set; }
        public string QueueName { get; set; }
    }
}