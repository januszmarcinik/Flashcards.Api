using Autofac;
using Flashcards.Infrastructure.Extensions;
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
            builder.RegisterInstance(_configuration.GetSettings<ImagesSettings>()).SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>()).SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<MongoSettings>()).SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<QueueSettings>()).SingleInstance();
        }
    }
}
