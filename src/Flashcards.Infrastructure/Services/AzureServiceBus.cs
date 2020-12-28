using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Flashcards.Core;
using Flashcards.Infrastructure.Settings;

namespace Flashcards.Infrastructure.Services
{
    internal class AzureServiceBus : IEventBus, IAsyncDisposable
    {
        private readonly ServiceBusClient _client;
        private readonly ServiceBusSender _sender;
        private readonly ServiceBusProcessor _processor;

        public AzureServiceBus(QueueSettings settings)
        {
            _client = new ServiceBusClient(settings.HostName);
            _sender = _client.CreateSender(settings.QueueName);
            _processor = _client.CreateProcessor(settings.QueueName, new ServiceBusProcessorOptions());
        }
        
        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var integrationEvent = IntegrationEvent.FromDomainEvent(@event);
            var body = integrationEvent.Serialize();
            var message = new ServiceBusMessage(body);
            _sender.SendMessageAsync(message);
        }

        public void Subscribe(Action<IEvent> processMessage)
        {
            _processor.ProcessMessageAsync += (args) =>
            {
                var body = args.Message.Body.ToArray();
                var integrationEvent = IntegrationEvent.Deserialize(body);
                var @event = integrationEvent.ToDomainEvent();
                processMessage(@event);

                return args.CompleteMessageAsync(args.Message);
            };
            _processor.ProcessErrorAsync += (args) => Task.CompletedTask;

            _processor.StartProcessingAsync();
        }

        public void Unsubscribe()
        {
            _processor.StopProcessingAsync();
        }

        public ValueTask DisposeAsync()
        {
            _sender.DisposeAsync();
            _processor.DisposeAsync();
            return _client.DisposeAsync();
        }
    }
}