using Flashcards.Application.Cache;
using Flashcards.Application.EventBus;
using Flashcards.Application.Tokens;
using Flashcards.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Application
{
    public static class ApplicationSetup
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) =>
            services
                .AddHostedService<QueueListener>()
                .AddSingleton<EncryptionService>()
                .AddSingleton<ITokenService, JwtTokenService>()
                .AddScoped<ICacheService, MemoryCacheService>();
    }
}