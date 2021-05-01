using Flashcards.Domain.Cards;
using Flashcards.Domain.Decks;
using Flashcards.Infrastructure.Extensions;
using Flashcards.Infrastructure.Mongo.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Flashcards.Infrastructure.Mongo
{
    public static class Extensions
    {
        public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            MongoConfiguration.Configure();
            var settings = configuration.GetSettings<MongoSettings>();

            return services
                .AddScoped<INoSqlCardsRepository, NoSqlCardsRepository>()
                .AddScoped<INoSqlDecksRepository, NoSqlDecksRepository>()
                .AddScoped(_ =>
                {
                    var client = new MongoClient(settings.ConnectionString);
                    var database = client.GetDatabase(settings.DatabaseName);

                    return new MongoDbContext(database);
                });
        }
    }
}
