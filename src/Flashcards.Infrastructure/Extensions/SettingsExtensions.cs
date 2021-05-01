using Flashcards.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure.Extensions
{
    public static class SettingsExtensions
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T : ISettings, new()
        {
            var configurationValue = new T();

            configuration.GetSection<T>().Bind(configurationValue);

            return configurationValue;
        }

        public static IServiceCollection AddSettings<T>(this IServiceCollection services, IConfiguration configuration) where T : class, ISettings => 
            services.Configure<T>(configuration.GetSection<T>());

        private static IConfigurationSection GetSection<T>(this IConfiguration configuration) where T : ISettings => 
            configuration.GetSection(typeof(T).Name.Replace("Settings", string.Empty));
    }
}
