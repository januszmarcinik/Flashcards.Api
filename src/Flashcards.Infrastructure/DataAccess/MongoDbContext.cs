using Flashcards.Domain.Cards;
using Flashcards.Infrastructure.Settings;
using MongoDB.Driver;

namespace Flashcards.Infrastructure.DataAccess
{
    internal class MongoDbContext
    {
        public MongoDbContext(MongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Cards = database.GetCollection<CardDto>("cards");
        }
        
        public IMongoCollection<CardDto> Cards { get; }
    }
}