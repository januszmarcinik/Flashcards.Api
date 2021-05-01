using Flashcards.Core;

namespace Flashcards.Infrastructure.BlobStorage
{
    public class AzureBlobStorageSettings : ISettings
    {
        public string StorageUrl { get; set; }
        public string ImagesContainerName { get; set; }
        public string ConnectionString { get; set; }
    }
}