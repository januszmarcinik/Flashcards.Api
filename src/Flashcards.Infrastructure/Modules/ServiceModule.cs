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
            builder.RegisterType<CategoriesQueryService>().As<ICategoriesQueryService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoriesCommandService>().As<ICategoriesCommandService>().InstancePerLifetimeScope();

            builder.RegisterType<UsersQueryService>().As<IUsersQueryService>().InstancePerLifetimeScope();
            builder.RegisterType<UsersCommandService>().As<IUsersCommandService>().InstancePerLifetimeScope();

            builder.RegisterType<DeckQueryService>().As<IDeckQueryService>().InstancePerLifetimeScope();
            builder.RegisterType<DeckCommandService>().As<IDeckCommandService>().InstancePerLifetimeScope();

            builder.RegisterType<CardsQueryService>().As<ICardsQueryService>().InstancePerLifetimeScope();
            builder.RegisterType<CardsCommandService>().As<ICardsCommandService>().InstancePerLifetimeScope();
        }
    }
}
