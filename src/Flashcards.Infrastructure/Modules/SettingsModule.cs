using Autofac;
using Flashcards.Infrastructure.Extensions;
using Flashcards.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace Flashcards.Infrastructure.Modules
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
        }
    }
}
