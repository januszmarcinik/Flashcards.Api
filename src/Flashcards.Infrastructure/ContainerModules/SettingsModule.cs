using Autofac;
using Flashcards.Application.Tokens;
using Flashcards.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace Flashcards.Infrastructure.ContainerModules
{
    public class SettingsModule : Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>()).SingleInstance();
        }
    }
}
