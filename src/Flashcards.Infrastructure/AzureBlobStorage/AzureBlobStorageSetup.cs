using Flashcards.Application.Images;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure.AzureBlobStorage
{
    public static class AzureBlobStorageSetup
    {
        public static IServiceCollection AddAzureBlobStorage(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSettings<AzureBlobStorageSettings>(configuration)
                .AddScoped<IImagesStorage, AzureImagesStorage>();
    }
}