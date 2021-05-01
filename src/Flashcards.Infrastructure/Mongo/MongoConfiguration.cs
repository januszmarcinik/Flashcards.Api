using Flashcards.Application.Cards;
using Flashcards.Application.Decks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Flashcards.Infrastructure.Mongo
{
    public class MongoConfiguration
    {
        public static void Configure()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

            BsonClassMap.RegisterClassMap<CardDto>(cm => 
            {
                cm.AutoMap();
            });
            
            BsonClassMap.RegisterClassMap<DeckDto>(cm => 
            {
                cm.AutoMap();
            });
        }
    }
}