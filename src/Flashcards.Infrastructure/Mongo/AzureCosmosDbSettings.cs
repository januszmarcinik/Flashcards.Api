using Flashcards.Core;

namespace Flashcards.Infrastructure.Mongo
{
    public class AzureCosmosDbSettings : ISettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
