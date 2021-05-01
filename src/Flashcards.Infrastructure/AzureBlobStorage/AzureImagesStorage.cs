using System;
using System.Collections.Generic;
using System.IO;
using Azure.Storage.Blobs;
using Flashcards.Application.Images;
using Microsoft.Extensions.Options;

namespace Flashcards.Infrastructure.AzureBlobStorage
{
    internal class AzureImagesStorage : IImagesStorage
    {
        private readonly BlobContainerClient _container;

        public AzureImagesStorage(IOptions<AzureBlobStorageSettings> settings)
        {
            var blobServiceClient = new BlobServiceClient(settings.Value.ConnectionString);
            _container = blobServiceClient.GetBlobContainerClient(settings.Value.ImagesContainerName);
            _container.CreateIfNotExists();
            VirtualPath = $"{settings.Value.StorageUrl}/{settings.Value.ImagesContainerName}";
        }

        public string VirtualPath { get; }

        public void SaveImages(string deck, Guid cardId, IEnumerable<ImageDataInfo> imagesData)
        {
            if (imagesData == null)
            {
                return;
            }
            
            foreach (var image in imagesData)
            {
                SaveTo(deck, cardId, image.ImageId, image.Data, image.Extension);
            }
        }

        public void RemoveImages(string deck, Guid cardId)
        {
            var cardsPath = $"{deck}/{cardId}";
            var blobs = _container.GetBlobs(prefix: cardsPath);
            foreach (var blob in blobs)
            {
                var blobClient = _container.GetBlobClient(blob.Name);
                blobClient.DeleteIfExists();
            }
        }
        
        private static string GetFileName(Guid imageId, string extension)
        {
            return extension.Contains(".") ? $"{imageId}{extension}" : $"{imageId}.{extension}";
        }

        private void SaveTo(string deck, Guid card, Guid imageId, byte[] bytes, string extension)
        {
            var fileName = Path.Combine(deck, card.ToString(), GetFileName(imageId, extension));
            var blob = _container.GetBlobClient(fileName);
            using var stream = new MemoryStream(bytes);
            blob.Upload(stream);
        }
    }
}
