using Flashcards.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure.RabbitMq
{
    public static class RabbitMqSetup
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSettings<RabbitMqSettings>(configuration)
                .AddScoped<IEventBus, RabbitMqEventBus>();
    }
}
