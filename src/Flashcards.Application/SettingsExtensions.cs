using Flashcards.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Application
{
    public static class SettingsExtensions
    {
        public static IServiceCollection AddSettings<T>(this IServiceCollection services, ISettingsRegistry settingsRegistry) where T : class, ISettings
        {
            settingsRegistry.AddSettings<T>();
            return services;
        }
    }
}
