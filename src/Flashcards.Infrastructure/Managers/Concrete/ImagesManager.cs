using Flashcards.Core.Extensions;
using Flashcards.Domain.Enums;
using Flashcards.Infrastructure.Managers.Abstract;
using System;
using System.IO;
using Flashcards.Core.Exceptions;
using Flashcards.Core.Settings;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Net;

namespace Flashcards.Infrastructure.Managers.Concrete
{
    internal class ImagesManager : IImagesManager
    {
        private readonly AppSettings _appSettings;
        private readonly IHostingEnvironment _hostingEnvironment;
        private List<SaveImageHelper> _imagesData;
        private readonly WebClient _webClient;

        public ImagesManager(AppSettings appSettings, IHostingEnvironment hostingEnvironment)
        {
            _appSettings = appSettings;
            _hostingEnvironment = hostingEnvironment;
            _webClient = new WebClient();
            _imagesData = new List<SaveImageHelper>();
        }

        public string GetVirtualPath(Topic topic, string category, string deck)
        {
            return Path.Combine(_appSettings.ImagesContainerFullPath, topic.GetDescription(), category, deck);
        }

        public string GetVirtualPath(Topic topic, string category, string deck, Guid cardId)
        {
            return Path.Combine(GetVirtualPath(topic, category, deck), cardId.ToString());
        }

        public string GetVirtualPath(Topic topic, string category, string deck, Guid cardId, Guid imageId, string extension)
        {
            return Path.Combine(GetVirtualPath(topic, category, deck, cardId), GetFileName(imageId, extension));
        }

        public string GetPhysicalPath(Topic topic, string category, string deck, Guid cardId)
        {
            return Path.Combine(_hostingEnvironment.WebRootPath, "images", topic.GetDescription(), category, deck, cardId.ToString());
        }

        public void SaveTo(Topic topic, string category, string deck, Guid card, Guid imageId, byte[] bytes, string extension)
        {
            var path = Path.Combine("wwwroot", "images", topic.GetDescription(), category, deck, card.ToString(), GetFileName(imageId, extension));
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

        private void CreateDirectoryIfNotExists(string path)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                }
            }
            catch (Exception ex)
            {
                throw new FlashcardsException(ErrorCode.DirectoryCannotBeCreated, path, ex);
            }
        }

        public string ProcessTextForEdit(Topic topic, string category, string deck, Guid cardId, string stringToAnalyze)
        {
            var startIndex = 0;
            var extension = string.Empty;

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
                    var path = GetVirtualPath(topic, category, deck, cardId, imageId, extension);
                    stringToAnalyze = stringToAnalyze.Replace(stringToAnalyze.Substring(startIndex, endIndex - startIndex), path);
                }
                else
                {
                    var imageSrc = stringToAnalyze.Substring(startIndex, endIndex - startIndex);
                    extension = imageSrc.Substring(imageSrc.LastIndexOf('.'));

                    try
                    {
                        var bytes = _webClient.DownloadData(imageSrc);
                        var imageId = Guid.NewGuid();
                        _imagesData.Add(new SaveImageHelper(imageId, bytes, extension));
                        var path = GetVirtualPath(topic, category, deck, cardId, imageId, extension);
                        stringToAnalyze = stringToAnalyze.Replace(stringToAnalyze.Substring(startIndex, endIndex - startIndex), path);
                    }
                    catch (Exception ex)
                    {
                        throw new FlashcardsException(ErrorCode.FileCannotBeDownloaded, imageSrc, ex);
                    }
                }
            }

            return stringToAnalyze;
        }

        public void SaveImages(Topic topic, string category, string deck, Guid cardId)
        {
            if (_imagesData != null)
            {
                foreach (var image in _imagesData)
                {
                    SaveTo(topic, category, deck, cardId, image.ImageId, image.Data, image.Extension);
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
