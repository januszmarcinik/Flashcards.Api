using Flashcards.Application;
using Flashcards.Application.Images;
using Flashcards.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure.AzureBlobStorage
{
    public static class AzureBlobStorageSetup
    {
        public static IServiceCollection AddAzureBlobStorage(this IServiceCollection services, ISettingsRegistry settings) =>
            services
                .AddSettings<AzureBlobStorageSettings>(settings)
                .AddScoped<IImagesStorage, AzureImagesStorage>();
    }
}