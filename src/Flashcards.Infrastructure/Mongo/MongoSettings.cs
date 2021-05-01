using Flashcards.Core;

namespace Flashcards.Infrastructure.Mongo
{
    public class MongoSettings : ISettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
