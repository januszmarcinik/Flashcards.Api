using Flashcards.Domain.Cards;
using MongoDB.Bson.Serialization;

namespace Flashcards.Infrastructure.DataAccess.Configurations
{
    public class MongoConfiguration
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<CardDto>(cm => 
            {
                cm.AutoMap();
            });
        }
    }
}