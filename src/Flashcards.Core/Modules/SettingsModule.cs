using Autofac;
using Flashcards.Core.Extensions;
using Flashcards.Core.Settings;
using Microsoft.Extensions.Configuration;

namespace Flashcards.Core.Modules
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
            builder.RegisterInstance(_configuration.GetSettings<AppSettings>()).SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<DatabaseSettings>()).SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>()).SingleInstance();
        }
    }
}
