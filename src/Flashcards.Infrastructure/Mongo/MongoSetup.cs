using Flashcards.Application.Cards;
using Flashcards.Application.Decks;
using Flashcards.Infrastructure.Mongo.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure.Mongo
{
    public static class MongoSetup
    {
        public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            MongoConfiguration.Configure();

            return services
                .AddSettings<MongoSettings>(configuration)
                .AddScoped<INoSqlCardsRepository, NoSqlCardsRepository>()
                .AddScoped<INoSqlDecksRepository, NoSqlDecksRepository>()
                .AddScoped<MongoDbContext>();
        }
    }
}
