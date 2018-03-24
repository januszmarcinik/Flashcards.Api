using Autofac;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using Flashcards.Infrastructure.Services.Abstract.Queries;
using Flashcards.Infrastructure.Services.Concrete.Commands;
using Flashcards.Infrastructure.Services.Concrete.Queries;

namespace Flashcards.Infrastructure.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UsersQueryService>().As<IUsersQueryService>().InstancePerLifetimeScope();
            builder.RegisterType<UsersCommandService>().As<IUsersCommandService>().InstancePerLifetimeScope();
        }
    }
}
