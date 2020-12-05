using Autofac;
using Flashcards.Infrastructure.DataAccess;
using Flashcards.Infrastructure.DataAccess.Configurations;

namespace Flashcards.Infrastructure.ContainerModules
{
    public class MongoModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MongoDbContext>().AsSelf().InstancePerLifetimeScope();
            MongoConfiguration.Configure();
        }
    }
}
