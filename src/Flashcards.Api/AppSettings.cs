using Flashcards.Core;

namespace Flashcards.Api
{
    public class AppSettings : ISettings
    {
        public string Name { get; set; }
        public string InfrastructureType { get; set; }
        
        public const string InfrastructureOnPremises = "OnPremises";
        public const string InfrastructureAzure = "Azure";
    }
}
