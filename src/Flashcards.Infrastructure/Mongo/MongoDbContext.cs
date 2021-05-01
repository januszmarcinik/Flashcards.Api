using Flashcards.Domain.Cards;
using Flashcards.Domain.Decks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Flashcards.Infrastructure.Mongo
{
    internal class MongoDbContext
    {
        public MongoDbContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            
            Cards = database.GetCollection<CardDto>("cards");
            Decks = database.GetCollection<DeckDto>("decks");
        }
        
        public IMongoCollection<CardDto> Cards { get; }
        
        public IMongoCollection<DeckDto> Decks { get; }
    }
}