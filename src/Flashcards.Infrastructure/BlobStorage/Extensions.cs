using Flashcards.Application.Images;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Infrastructure.BlobStorage
{
    public static class Extensions
    {
        public static IServiceCollection AddAzureBlobStorage(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSettings<AzureBlobStorageSettings>(configuration)
                .AddScoped<IImagesStorage, AzureImagesStorage>();
    }
}