using Flashcards.Domain.Cards;
using Flashcards.Domain.Decks;
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