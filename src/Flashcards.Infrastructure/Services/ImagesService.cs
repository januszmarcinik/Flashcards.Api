using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Flashcards.Domain.Cards;
using Flashcards.Infrastructure.Settings;
using Microsoft.AspNetCore.Hosting;

namespace Flashcards.Infrastructure.Services
{
    internal class ImagesService : IImagesService
    {
        private readonly AppSettings _appSettings;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly List<SaveImageHelper> _imagesData;
        private readonly WebClient _webClient;

        public ImagesService(AppSettings appSettings, IHostingEnvironment hostingEnvironment)
        {
            _appSettings = appSettings;
            _hostingEnvironment = hostingEnvironment;
            _webClient = new WebClient();
            _imagesData = new List<SaveImageHelper>();
        }

        public string GetVirtualPath(string deck)
        {
            return Path.Combine(_appSettings.ImagesContainerFullPath, deck);
        }

        public string GetVirtualPath(string deck, Guid cardId)
        {
            return Path.Combine(GetVirtualPath(deck), cardId.ToString());
        }

        public string GetVirtualPath(string deck, Guid cardId, Guid imageId, string extension)
        {
            return Path.Combine(GetVirtualPath(deck, cardId), GetFileName(imageId, extension));
        }

        public string GetPhysicalPath(string deck, Guid cardId)
        {
            return Path.Combine(_hostingEnvironment.WebRootPath, "images", deck, cardId.ToString());
        }

        public void SaveTo(string deck, Guid card, Guid imageId, byte[] bytes, string extension)
        {
            var path = Path.Combine("wwwroot", "images", deck, card.ToString(), GetFileName(imageId, extension));
            CreateDirectoryIfNotExists(path);
            File.WriteAllBytes(path, bytes);
        }

        public void RemoveDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
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

        public string ProcessTextForEdit(string deck, Guid cardId, string stringToAnalyze)
        {
            var startIndex = 0;

            while (startIndex >= 0 && startIndex <= stringToAnalyze.Length)
            {
                startIndex = stringToAnalyze.IndexOf("src", startIndex);
                if (startIndex == -1)
                {
                    break;
                }

                startIndex += 5;
                var endIndex = stringToAnalyze.IndexOf('"', startIndex);

                var baseIndex = stringToAnalyze.IndexOf("base64", startIndex);
                string extension;
                if (baseIndex >= 0)
                {
                    var slashIndex = stringToAnalyze.IndexOf('/', startIndex);
                    extension = stringToAnalyze.Substring(slashIndex, stringToAnalyze.IndexOf(';', slashIndex) - slashIndex)
                        .Replace('/', '.');
                    var bytesStartIndex = stringToAnalyze.IndexOf(',', baseIndex) + 1;
                    var bytesString = stringToAnalyze.Substring(bytesStartIndex, endIndex - bytesStartIndex);
                    var bytes = Convert.FromBase64String(bytesString);
                    var imageId = Guid.NewGuid();
                    _imagesData.Add(new SaveImageHelper(imageId, bytes, extension));
                    var path = GetVirtualPath(deck, cardId, imageId, extension);
                    stringToAnalyze = stringToAnalyze.Replace(stringToAnalyze.Substring(startIndex, endIndex - startIndex), path);
                }
                else
                {
                    var imageSrc = stringToAnalyze.Substring(startIndex, endIndex - startIndex);
                    extension = imageSrc.Substring(imageSrc.LastIndexOf('.'));

                    var bytes = _webClient.DownloadData(imageSrc);
                    var imageId = Guid.NewGuid();
                    _imagesData.Add(new SaveImageHelper(imageId, bytes, extension));
                    var path = GetVirtualPath(deck, cardId, imageId, extension);
                    stringToAnalyze = stringToAnalyze.Replace(stringToAnalyze.Substring(startIndex, endIndex - startIndex), path);
                }
            }

            return stringToAnalyze;
        }

        public void SaveImages(string deck, Guid cardId)
        {
            if (_imagesData != null)
            {
                foreach (var image in _imagesData)
                {
                    SaveTo(deck, cardId, image.ImageId, image.Data, image.Extension);
                }
            }
        }
    }

    public class SaveImageHelper
    {
        public Guid ImageId { get; }
        public byte[] Data { get; }
        public string Extension { get; }

        public SaveImageHelper(Guid imageId, byte[] data, string extension)
        {
            ImageId = imageId;
            Data = data;
            Extension = extension;
        }
    }
}
