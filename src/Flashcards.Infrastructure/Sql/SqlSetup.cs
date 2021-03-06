﻿using Flashcards.Application.Cards;
using Flashcards.Application.Comments;
using Flashcards.Application.Decks;
using Flashcards.Application.Sessions;
using Flashcards.Application.Users;
using Flashcards.Core;
using Flashcards.Infrastructure.Sql.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure.Sql
{
    public static class SqlSetup
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services, ISettingsRegistry settingsRegistry)
        {
            var settings = settingsRegistry.GetSettings<SqlServerSettings>();
            
            return services
                .AddDbContext<EFContext>(options =>
                {
                    options.UseSqlServer(settings.ConnectionString);
                })
                .AddRepositories();
        }

        public static IServiceCollection AddAzureSql(this IServiceCollection services, ISettingsRegistry settingsRegistry)
        {
            var settings = settingsRegistry.GetSettings<AzureSqlSettings>();
            
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