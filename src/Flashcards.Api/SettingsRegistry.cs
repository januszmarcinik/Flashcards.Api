using Flashcards.Api.Configuration;
using Flashcards.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Api
{
    public class SettingsRegistry : ISettingsRegistry
    {
        private readonly IServiceCollection _services;
        private readonly IConfiguration _configuration;

        public SettingsRegistry(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        public T GetSettings<T>() where T : ISettings, new() => 
            _configuration.GetSettings<T>();

        public void AddSettings<T>() where T : class, ISettings => 
            _services.AddSettings<T>(_configuration);
    }
}