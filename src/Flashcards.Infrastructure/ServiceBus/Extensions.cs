using Flashcards.Core;
using Flashcards.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure.ServiceBus
{
    public static class Extensions
    {
        public static IServiceCollection AddAzureServiceBus(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSettings<AzureServiceBusSettings>(configuration)
                .AddScoped<IEventBus, AzureServiceBus>();
    }
}
