using Autofac;
using Flashcards.Domain;
using Flashcards.Domain.Users;
using Flashcards.Infrastructure.Services;

namespace Flashcards.Infrastructure.ContainerModules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EncryptionService>().AsSelf().SingleInstance();
            builder.RegisterType<JwtTokenService>().As<ITokenService>().SingleInstance();
            builder.RegisterType<MemoryCacheService>().As<ICacheService>().InstancePerLifetimeScope();
        }
    }
}
