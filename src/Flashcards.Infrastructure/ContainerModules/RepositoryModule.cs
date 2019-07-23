using Autofac;
using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.Repositories;

namespace Flashcards.Infrastructure.ContainerModules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoriesRepository>().As<ICategoriesRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UsersRepository>().As<IUsersRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DecksRepository>().As<IDecksRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CardsRepository>().As<ICardsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CommentsRepository>().As<ICommentsRepository>().InstancePerLifetimeScope();
        }
    }
}
