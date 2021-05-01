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
        public static IServiceCollection AddMongo(this IServiceCollection services, ISettingsRegistry settings)
        {
            MongoConfiguration.Configure();

            return services
                .AddSettings<MongoSettings>(settings)
                .AddScoped<INoSqlCardsRepository, NoSqlCardsRepository>()
                .AddScoped<INoSqlDecksRepository, NoSqlDecksRepository>()
                .AddScoped<MongoDbContext>();
        }
    }
}
