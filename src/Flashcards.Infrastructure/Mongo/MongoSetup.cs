using Flashcards.Application;
using Flashcards.Application.Cards;
using Flashcards.Application.Decks;
using Flashcards.Core;
using Flashcards.Infrastructure.Mongo.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure.Mongo
{
    public static class MongoSetup
    {
        public static IServiceCollection AddMongo(this IServiceCollection services, ISettingsRegistry settings) =>
            services
                .AddSettings<MongoSettings>(settings)
                .AddCommonServices(settings);

        public static IServiceCollection AddAzureCosmosDb(this IServiceCollection services, ISettingsRegistry settings) =>
            services
                .AddSettings<AzureCosmosDbSettings>(settings)
                .AddCommonServices(settings);

        private static IServiceCollection AddCommonServices(this IServiceCollection services, ISettingsRegistry settings)
        {
            MongoConfiguration.Configure();

            return services
                .AddScoped<INoSqlCardsRepository, MongoCardsRepository>()
                .AddScoped<INoSqlDecksRepository, MongoDecksRepository>()
                .AddScoped<MongoDbContext>();
        }
    }
}
