using System;
using System.Collections.Generic;
using System.IO;
using Azure.Storage.Blobs;
using Flashcards.Domain.Images;
using Flashcards.Infrastructure.Settings;

namespace Flashcards.Infrastructure.Services
{
    internal class AzureImagesStorage : IImagesStorage
    {
        private readonly ImagesSettings _imagesSettings;
        private readonly BlobContainerClient _container;
        private const string ContainerName = "images";

        public AzureImagesStorage(ImagesSettings imagesSettings)
        {
            _imagesSettings = imagesSettings;
            var blobServiceClient = new BlobServiceClient(imagesSettings.ConnectionString);
            _container = blobServiceClient.GetBlobContainerClient(ContainerName);
            _container.CreateIfNotExists();
        }

        public string VirtualPath => $"{_imagesSettings.ImagesContainerFullPath}/{ContainerName}";

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
