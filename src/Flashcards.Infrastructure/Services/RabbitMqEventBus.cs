using System;
using Flashcards.Core;
using Flashcards.Infrastructure.Settings;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Flashcards.Infrastructure.Services
{
    internal class RabbitMqEventBus : IEventBus, IDisposable
    {
        private readonly QueueSettings _settings;
        private readonly IMediator _mediator;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqEventBus(QueueSettings settings, IMediator mediator)
        {
            _settings = settings;
            _mediator = mediator;
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
        
        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var integrationEvent = IntegrationEvent.FromDomainEvent(@event);
            var body = integrationEvent.Serialize();

            _channel.BasicPublish(exchange: "",
                routingKey: _settings.QueueName,
                basicProperties: null,
                body: body);
        }

        public void Subscribe()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var integrationEvent = IntegrationEvent.Deserialize(body);
                var @event = integrationEvent.ToDomainEvent();
                _mediator.Publish(@event);
            };
            _channel.BasicConsume(queue: _settings.QueueName,
                autoAck: true,
                consumer: consumer);
        }

        public void Dispose()
        {
            _connection.Dispose();
            _channel.Dispose();
        }
    }
}