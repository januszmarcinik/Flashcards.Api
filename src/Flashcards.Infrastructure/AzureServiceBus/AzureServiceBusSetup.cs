using Flashcards.Application;
using Flashcards.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure.AzureServiceBus
{
    public static class AzureServiceBusSetup
    {
        public static IServiceCollection AddAzureServiceBus(this IServiceCollection services, ISettingsRegistry settings) =>
            services
                .AddSettings<AzureServiceBusSettings>(settings)
                .AddScoped<IEventBus, AzureServiceBus>();
    }
}
