using System.Linq;
using System.Text;
using Flashcards.Application.Cards;
using Flashcards.Core;
using Newtonsoft.Json;

namespace Flashcards.Infrastructure.Services
{
    public class IntegrationEvent
    {
        [JsonConstructor]
        private IntegrationEvent(string type, string body)
        {
            Type = type;
            Body = body;
        }

        public string Type { get; }
        public string Body { get; }

        public static IntegrationEvent FromDomainEvent<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var body = JsonConvert.SerializeObject(@event);
            return new IntegrationEvent(@event.GetType().Name, body);
        }

        public IEvent ToDomainEvent()
        {
            var type = typeof(Card).Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == Type);
            return type == null ? null : (IEvent)JsonConvert.DeserializeObject(Body, type);
        }

        public byte[] Serialize()
        {
            var body = JsonConvert.SerializeObject(this);
            return Encoding.UTF8.GetBytes(body);
        }

        public static IntegrationEvent Deserialize(byte[] bytes)
        {
            var body = Encoding.UTF8.GetString(bytes);
            return JsonConvert.DeserializeObject<IntegrationEvent>(body);
        }
    }
}