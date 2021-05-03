using Flashcards.Application.Cards;
using Flashcards.Application.Decks;
using MongoDB.Driver;

namespace Flashcards.Infrastructure.Mongo
{
    internal class MongoDbContext
    {
        public MongoDbContext(IMongoDatabase database)
        {
            Cards = database.GetCollection<CardDto>("cards");
            Decks = database.GetCollection<DeckDto>("decks");
        }
        
        public IMongoCollection<CardDto> Cards { get; }
        
        public IMongoCollection<DeckDto> Decks { get; }
    }
}