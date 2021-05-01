using Flashcards.Domain.Cards;
using Flashcards.Domain.Decks;
using Flashcards.Infrastructure.Extensions;
using Flashcards.Infrastructure.Mongo.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure.Mongo
{
    public static class Extensions
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
