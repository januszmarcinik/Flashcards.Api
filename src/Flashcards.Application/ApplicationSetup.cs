using Flashcards.Application.Cache;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Application
{
    public static class ApplicationSetup
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) =>
            services
                .AddScoped<ICacheService, MemoryCacheService>();
    }
}