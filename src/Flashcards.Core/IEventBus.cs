using System;
using System.Threading.Tasks;

namespace Flashcards.Core
{
    public interface IEventBus
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;

        Task SubscribeAsync(Action<IEvent> processMessage);

        Task UnsubscribeAsync();
    }
}