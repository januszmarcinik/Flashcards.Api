using Flashcards.Core;

namespace Flashcards.Infrastructure.Sql
{
    public class SqlServerSettings : ISettings
    {
        public string ConnectionString { get; set; }
    }
    
    public class AzureSqlSettings : ISettings
    {
        public string ConnectionString { get; set; }
    }
}
