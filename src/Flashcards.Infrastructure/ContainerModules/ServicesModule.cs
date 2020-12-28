using Autofac;
using Flashcards.Domain;
using Flashcards.Domain.Images;
using Flashcards.Domain.Users;
using Flashcards.Infrastructure.Extensions;
using Flashcards.Infrastructure.Services;
using Flashcards.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace Flashcards.Infrastructure.ContainerModules
{
    public class ServicesModule : Module
    {
        private readonly IConfiguration _configuration;

        public ServicesModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            var settings = _configuration.GetSettings<AppSettings>();
            if (settings.IsCloud)
            {
                builder.RegisterType<AzureImagesStorage>().As<IImagesStorage>().InstancePerLifetimeScope();
            }
            else
            {
                builder.RegisterType<WindowsImagesStorage>().As<IImagesStorage>().InstancePerLifetimeScope();
            }
            
            builder.RegisterType<EncryptionService>().AsSelf().SingleInstance();
            builder.RegisterType<JwtTokenService>().As<ITokenService>().SingleInstance();
            builder.RegisterType<MemoryCacheService>().As<ICacheService>().InstancePerLifetimeScope();
        }
    }
}
