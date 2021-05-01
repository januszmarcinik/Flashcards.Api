using System;
using System.Threading;
using System.Threading.Tasks;
using Flashcards.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Flashcards.Application.EventBus
{
    public class QueueListener : IHostedService
    {
        private readonly IEventBus _eventBus;
        private readonly IServiceProvider _serviceProvider;

        public QueueListener(IEventBus eventBus, IServiceProvider serviceProvider)
        {
            _eventBus = eventBus;
            _serviceProvider = serviceProvider;
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _eventBus.Subscribe(ProcessMessage);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _eventBus.Unsubscribe();
            return Task.CompletedTask;
        }

        private void ProcessMessage(IEvent @event)
        {
            using var childScope = _serviceProvider.CreateScope();
            var mediator = childScope.ServiceProvider.GetService<IMediator>();
            mediator.Publish(@event);
        }
    }
}