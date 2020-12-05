using Autofac;
using Flashcards.Domain.Cards;
using Flashcards.Domain.Comments;
using Flashcards.Domain.Decks;
using Flashcards.Domain.Sessions;
using Flashcards.Domain.Users;
using Flashcards.Infrastructure.Repositories;

namespace Flashcards.Infrastructure.ContainerModules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UsersRepository>().As<IUsersRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DecksRepository>().As<IDecksRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SqlCardsRepository>().As<ISqlCardsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<NoSqlCardsRepository>().As<INoSqlCardsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SqlCommentsRepository>().As<ISqlCommentsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SessionsRepository>().As<ISessionsRepository>().InstancePerLifetimeScope();
        }
    }
}
