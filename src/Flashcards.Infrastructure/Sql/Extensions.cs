using Flashcards.Domain.Cards;
using Flashcards.Domain.Comments;
using Flashcards.Domain.Decks;
using Flashcards.Domain.Sessions;
using Flashcards.Domain.Users;
using Flashcards.Infrastructure.Extensions;
using Flashcards.Infrastructure.Sql.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure.Sql
{
    public static class Extensions
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSettings<SqlServerSettings>();
            
            return services
                .AddDbContext<EFContext>(options =>
                {
                    options.UseSqlServer(settings.ConnectionString);
                })
                .AddRepositories();
        }

        public static IServiceCollection AddAzureSql(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSettings<AzureSqlSettings>();
            
            return services
                .AddDbContext<EFContext>(options =>
                {
                    options.UseSqlServer(settings.ConnectionString);
                })
                .AddRepositories();
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services
                .AddScoped<IUsersRepository, UsersRepository>()
                .AddScoped<ISqlDecksRepository, SqlDecksRepository>()
                .AddScoped<ISqlCardsRepository, SqlCardsRepository>()
                .AddScoped<ISqlCommentsRepository, SqlCommentsRepository>()
                .AddScoped<ISessionsRepository, SessionsRepository>();
    }
}