using Flashcards.Domain.Cards;
using Flashcards.Domain.Decks;
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
            Decks = database.GetCollection<DeckDto>("decks");
        }
        
        public IMongoCollection<CardDto> Cards { get; }
        
        public IMongoCollection<DeckDto> Decks { get; }
    }
}