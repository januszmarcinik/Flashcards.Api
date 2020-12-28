using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Flashcards.Core;
using Microsoft.Extensions.Hosting;

namespace Flashcards.Infrastructure.Services
{
    public class QueueListener : IHostedService
    {
        private readonly IEventBus _eventBus;
        private readonly ILifetimeScope _lifetimeScope;

        public QueueListener(IEventBus eventBus, ILifetimeScope lifetimeScope)
        {
            _eventBus = eventBus;
            _lifetimeScope = lifetimeScope;
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
            using var childScope = _lifetimeScope.BeginLifetimeScope();
            var mediator = childScope.Resolve<IMediator>();
            mediator.Publish(@event);
        }
    }
}