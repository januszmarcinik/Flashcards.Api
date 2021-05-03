using System.Security.Authentication;
using Flashcards.Application.Cards;
using Flashcards.Application.Decks;
using Flashcards.Core;
using Flashcards.Infrastructure.Mongo.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Flashcards.Infrastructure.Mongo
{
    public static class MongoSetup
    {
        public static IServiceCollection AddMongo(this IServiceCollection services, ISettingsRegistry settingsRegistry)
        {
            var settings = settingsRegistry.GetSettings<MongoSettings>();
            return services.AddMongoDbContext(settings.ConnectionString, settings.DatabaseName);
        }

        public static IServiceCollection AddAzureCosmosDb(this IServiceCollection services,
            ISettingsRegistry settingsRegistry)
        {
            var settings = settingsRegistry.GetSettings<AzureCosmosDbSettings>();
            return services.AddMongoDbContext(settings.ConnectionString, settings.DatabaseName);
        }

        private static IServiceCollection AddMongoDbContext(this IServiceCollection services, string connectionString, string databaseName)
        {
            MongoConfiguration.Configure();

            return services
                .AddScoped<INoSqlCardsRepository, MongoCardsRepository>()
                .AddScoped<INoSqlDecksRepository, MongoDecksRepository>()
                .AddScoped(_ =>
                {
                    var mongoSettings = MongoClientSettings.FromUrl(
                        new MongoUrl(connectionString)
                    );
                    mongoSettings.SslSettings = new SslSettings {EnabledSslProtocols = SslProtocols.Tls12};

                    var client = new MongoClient(mongoSettings);
                    var database = client.GetDatabase(databaseName);

                    return new MongoDbContext(database);
                });
        }
    }
}