using Flashcards.Application.Cache;
using Flashcards.Application.EventBus;
using Flashcards.Application.Tokens;
using Flashcards.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Application
{
    public static class ApplicationSetup
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, ISettingsRegistry settings) =>
            services
                .AddHostedService<QueueListener>()
                .AddSingleton<EncryptionService>()
                .AddSettings<JwtSettings>(settings)
                .AddSingleton<ITokenService, JwtTokenService>()
                .AddScoped<ICacheService, MemoryCacheService>();
    }
}