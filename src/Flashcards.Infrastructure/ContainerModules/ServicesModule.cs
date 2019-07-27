using Autofac;
using Flashcards.Domain.Cards;
using Flashcards.Domain.Sessions;
using Flashcards.Domain.Users;
using Flashcards.Infrastructure.Services;

namespace Flashcards.Infrastructure.ContainerModules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EncryptionService>().AsSelf().SingleInstance();
            builder.RegisterType<ImagesService>().As<IImagesService>().InstancePerLifetimeScope();
            builder.RegisterType<JwtTokenService>().As<ITokenService>().SingleInstance();
            builder.RegisterType<SessionsService>().As<ISessionsService>().InstancePerLifetimeScope();
            builder.RegisterType<MemoryCacheService>().As<ICacheService>().InstancePerLifetimeScope();
        }
    }
}
