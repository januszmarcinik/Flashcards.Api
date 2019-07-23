using Autofac;
using Flashcards.Infrastructure.Managers.Abstract;
using Flashcards.Infrastructure.Managers.Concrete;

namespace Flashcards.Infrastructure.ContainerModules
{
    public class ManagerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EncryptionManager>().As<IEncryptionManager>().SingleInstance();
            builder.RegisterType<ImagesManager>().As<IImagesManager>().InstancePerLifetimeScope();
            builder.RegisterType<JwtManager>().As<IJwtManager>().SingleInstance();
            builder.RegisterType<TestDataSeedingManager>().As<ITestDataSeedingManager>().InstancePerLifetimeScope();
            builder.RegisterType<SessionsManager>().As<ISessionsManager>().InstancePerLifetimeScope();
        }
    }
}
