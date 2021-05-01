using Flashcards.Infrastructure.AzureBlobStorage;
using Flashcards.Infrastructure.AzureServiceBus;
using Flashcards.Infrastructure.Mongo;
using Flashcards.Infrastructure.RabbitMq;
using Flashcards.Infrastructure.Sql;
using Flashcards.Infrastructure.WindowsStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure
{
    public static class InfrastructureSetup
    {
        public static IServiceCollection AddCloudInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration) =>
            services
                .AddAzureSql(configuration)
                .AddAzureBlobStorage(configuration)
                .AddAzureServiceBus(configuration);
        // TODO: AddCosmosDb()

        public static IServiceCollection AddOnPremisesInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration) =>
            services
                .AddSqlServer(configuration)
                .AddWindowsStorage(configuration)
                .AddRabbitMq(configuration)
                .AddMongo(configuration);
    }
}