using System;
using System.Collections.Generic;
using System.IO;
using Flashcards.Domain.Images;
using Flashcards.Infrastructure.Settings;
using Microsoft.AspNetCore.Hosting;

namespace Flashcards.Infrastructure.Services
{
    internal class WindowsImagesStorage : IImagesStorage
    {
        private readonly ImagesSettings _imagesSettings;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public WindowsImagesStorage(ImagesSettings imagesSettings, IWebHostEnvironment hostingEnvironment)
        {
            _imagesSettings = imagesSettings;
            _hostingEnvironment = hostingEnvironment;
        }

        public string VirtualPath => _imagesSettings.ImagesContainerFullPath;

        public void SaveImages(string deck, Guid cardId, IEnumerable<ImageDataInfo> imagesData)
        {
            if (imagesData != null)
            {
                foreach (var image in imagesData)
                {
                    SaveTo(deck, cardId, image.ImageId, image.Data, image.Extension);
                }
            }
        }

        public void RemoveImages(string deck, Guid cardId)
        {
            var path = GetPhysicalPath(deck, cardId);
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }
        
        private string GetPhysicalPath(string deck, Guid cardId)
        {
            return Path.Combine(_hostingEnvironment.WebRootPath, "images", deck, cardId.ToString());
        }

        private string GetFileName(Guid imageId, string extension)
        {
            return extension.Contains(".") ? $"{imageId}{extension}" : $"{imageId}.{extension}";
        }

        private static void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
        }
        
        private void SaveTo(string deck, Guid card, Guid imageId, byte[] bytes, string extension)
        {
            var path = Path.Combine("wwwroot", "images", deck, card.ToString(), GetFileName(imageId, extension));
            CreateDirectoryIfNotExists(path);
            File.WriteAllBytes(path, bytes);
        }
    }
}
