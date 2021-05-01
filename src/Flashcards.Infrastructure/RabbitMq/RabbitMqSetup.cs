using Flashcards.Application;
using Flashcards.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure.RabbitMq
{
    public static class RabbitMqSetup
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, ISettingsRegistry settings) =>
            services
                .AddSettings<RabbitMqSettings>(settings)
                .AddScoped<IEventBus, RabbitMqEventBus>();
    }
}
