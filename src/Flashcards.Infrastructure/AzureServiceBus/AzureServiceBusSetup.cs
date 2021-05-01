using Flashcards.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure.AzureServiceBus
{
    public static class AzureServiceBusSetup
    {
        public static IServiceCollection AddAzureServiceBus(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSettings<AzureServiceBusSettings>(configuration)
                .AddScoped<IEventBus, AzureServiceBus>();
    }
}
