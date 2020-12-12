using System.Threading;
using System.Threading.Tasks;
using Flashcards.Core;
using Microsoft.Extensions.Hosting;

namespace Flashcards.Infrastructure.Services
{
    public class QueueListener : IHostedService
    {
        private readonly IEventBus _eventBus;

        public QueueListener(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _eventBus.Subscribe();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}