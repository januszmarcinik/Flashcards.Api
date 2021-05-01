using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Flashcards.Application.Images
{
    public class ImagesProcessor
    {
        private readonly string _virtualPath;
        private readonly WebClient _webClient;
        private readonly List<ImageDataInfo> _imagesData;

        public ImagesProcessor(string virtualPath)
        {
            _virtualPath = virtualPath;
            _webClient = new WebClient();
            _imagesData = new List<ImageDataInfo>();
        }

        public IEnumerable<ImageDataInfo> ImagesData => _imagesData;
        
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
                    _imagesData.Add(new ImageDataInfo(imageId, bytes, extension));
                    var path = GetVirtualPath(deck, cardId, imageId, extension);
                    stringToAnalyze = stringToAnalyze.Replace(stringToAnalyze.Substring(startIndex, endIndex - startIndex), path);
                }
                else
                {
                    var imageSrc = stringToAnalyze.Substring(startIndex, endIndex - startIndex);
                    extension = imageSrc.Substring(imageSrc.LastIndexOf('.'));

                    var bytes = _webClient.DownloadData(imageSrc);
                    var imageId = Guid.NewGuid();
                    _imagesData.Add(new ImageDataInfo(imageId, bytes, extension));
                    var path = GetVirtualPath(deck, cardId, imageId, extension);
                    stringToAnalyze = stringToAnalyze.Replace(stringToAnalyze.Substring(startIndex, endIndex - startIndex), path);
                }
            }

            return stringToAnalyze;
        }
        
        private string GetVirtualPath(string deck, Guid cardId, Guid imageId, string extension)
        {
            return Path.Combine(
                _virtualPath,
                deck,
                cardId.ToString(),
                GetFileName(imageId, extension));
        }
        
        private static string GetFileName(Guid imageId, string extension)
        {
            return extension.Contains(".") ? $"{imageId}{extension}" : $"{imageId}.{extension}";
        }
    }
}