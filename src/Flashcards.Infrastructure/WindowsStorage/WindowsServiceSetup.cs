using Flashcards.Application;
using Flashcards.Application.Images;
using Flashcards.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure.WindowsStorage
{
    public static class WindowsServiceSetup
    {
        public static IServiceCollection AddWindowsStorage(this IServiceCollection services, ISettingsRegistry settings) =>
            services
                .AddSettings<WindowsStorageSettings>(settings)
                .AddScoped<IImagesStorage, WindowsImagesStorage>();
    }
}