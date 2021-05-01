using Flashcards.Core;
using Flashcards.Infrastructure.AzureBlobStorage;
using Flashcards.Infrastructure.AzureServiceBus;
using Flashcards.Infrastructure.Mongo;
using Flashcards.Infrastructure.RabbitMq;
using Flashcards.Infrastructure.Sql;
using Flashcards.Infrastructure.WindowsStorage;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure
{
    public static class InfrastructureSetup
    {
        public static IServiceCollection AddCloudInfrastructure(
            this IServiceCollection services,
            ISettingsRegistry settings) =>
            services
                .AddAzureSql(settings)
                .AddAzureBlobStorage(settings)
                .AddAzureServiceBus(settings);
        // TODO: AddCosmosDb()

        public static IServiceCollection AddOnPremisesInfrastructure(
            this IServiceCollection services,
            ISettingsRegistry settings) =>
            services
                .AddSqlServer(settings)
                .AddWindowsStorage(settings)
                .AddRabbitMq(settings)
                .AddMongo(settings);
    }
}