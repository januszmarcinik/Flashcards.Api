using System;
using System.Threading.Tasks;
using Flashcards.Application.EventBus;
using Flashcards.Core;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Flashcards.Infrastructure.RabbitMq
{
    internal class RabbitMqEventBus : IEventBus, IDisposable
    {
        private readonly RabbitMqSettings _settings;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqEventBus(IOptions<RabbitMqSettings> settings)
        {
            _settings = settings.Value;
            var factory = new ConnectionFactory
            {
                HostName = _settings.HostName
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            
            _channel.QueueDeclare(queue: _settings.QueueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }
        
        public Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var integrationEvent = IntegrationEvent.FromDomainEvent(@event);
            var body = integrationEvent.Serialize();

            _channel.BasicPublish(exchange: "",
                routingKey: _settings.QueueName,
                basicProperties: null,
                body: body);
            
            return Task.CompletedTask;
        }

        public Task SubscribeAsync(Action<IEvent> processMessage)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var integrationEvent = IntegrationEvent.Deserialize(body);
                var @event = integrationEvent.ToDomainEvent();
                processMessage(@event);
            };
            _channel.BasicConsume(queue: _settings.QueueName,
                autoAck: true,
                consumer: consumer);
            
            return Task.CompletedTask;
        }

        public Task UnsubscribeAsync()
        {
            _channel.Close();
            
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _connection.Dispose();
            _channel.Dispose();
        }
    }
}