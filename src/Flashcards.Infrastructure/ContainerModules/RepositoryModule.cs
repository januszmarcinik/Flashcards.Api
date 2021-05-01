using Autofac;
using Flashcards.Domain.Cards;
using Flashcards.Domain.Decks;
using Flashcards.Infrastructure.Repositories;

namespace Flashcards.Infrastructure.ContainerModules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NoSqlDecksRepository>().As<INoSqlDecksRepository>().InstancePerLifetimeScope();
            builder.RegisterType<NoSqlCardsRepository>().As<INoSqlCardsRepository>().InstancePerLifetimeScope();
        }
    }
}
