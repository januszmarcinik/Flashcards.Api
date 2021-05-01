using System.Security.Authentication;
using Flashcards.Application.Cards;
using Flashcards.Application.Decks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Flashcards.Infrastructure.Mongo
{
    internal class MongoDbContext
    {
        public MongoDbContext(IOptions<MongoSettings> settings)
        {
            var mongoSettings = MongoClientSettings.FromUrl(
                new MongoUrl(settings.Value.ConnectionString)
            );
            mongoSettings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };
            
            var client = new MongoClient(mongoSettings);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            
            Cards = database.GetCollection<CardDto>("cards");
            Decks = database.GetCollection<DeckDto>("decks");
        }
        
        public IMongoCollection<CardDto> Cards { get; }
        
        public IMongoCollection<DeckDto> Decks { get; }
    }
}