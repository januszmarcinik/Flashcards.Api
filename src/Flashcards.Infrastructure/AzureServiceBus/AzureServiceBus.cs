using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Flashcards.Application.EventBus;
using Flashcards.Core;
using Microsoft.Extensions.Options;

namespace Flashcards.Infrastructure.AzureServiceBus
{
    internal class AzureServiceBus : IEventBus, IAsyncDisposable
    {
        private readonly ServiceBusClient _client;
        private readonly ServiceBusSender _sender;
        private readonly ServiceBusProcessor _processor;

        public AzureServiceBus(IOptions<AzureServiceBusSettings> settings)
        {
            _client = new ServiceBusClient(settings.Value.ConnectionString);
            _sender = _client.CreateSender(settings.Value.QueueName);
            _processor = _client.CreateProcessor(settings.Value.QueueName, new ServiceBusProcessorOptions());
        }
        
        public Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var integrationEvent = IntegrationEvent.FromDomainEvent(@event);
            var body = integrationEvent.Serialize();
            var message = new ServiceBusMessage(body);
            return _sender.SendMessageAsync(message);
        }

        public Task SubscribeAsync(Action<IEvent> processMessage)
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

            return _processor.StartProcessingAsync();
        }

        public Task UnsubscribeAsync()
        {
            return _processor.StopProcessingAsync();
        }

        public ValueTask DisposeAsync()
        {
            _sender.DisposeAsync();
            _processor.DisposeAsync();
            return _client.DisposeAsync();
        }
    }
}