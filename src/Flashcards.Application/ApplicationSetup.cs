using Flashcards.Application.Cache;
using Flashcards.Application.EventBus;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Application
{
    public static class ApplicationSetup
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) =>
            services
                .AddHostedService<QueueListener>()
                .AddScoped<ICacheService, MemoryCacheService>();
    }
}