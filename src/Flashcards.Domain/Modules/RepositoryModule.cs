using Autofac;
using Flashcards.Domain.Repositories.Abstract;
using Flashcards.Domain.Repositories.Concrete;

namespace Flashcards.Domain.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EFUsersRepository>().As<IUsersRepository>().InstancePerLifetimeScope();
        }
    }
}
