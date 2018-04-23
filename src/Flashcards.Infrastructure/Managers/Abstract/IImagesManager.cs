using Flashcards.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Flashcards.Infrastructure.Managers.Abstract
{
    public interface IImagesManager
    {
        string GetVirtualPath(Topic topic, string category, string deck);
        string GetVirtualPath(Topic topic, string category, string deck, Guid cardId);
        string GetVirtualPath(Topic topic, string category, string deck, Guid cardId, Guid imageId, string extensions);
        string GetPhysicalPath(Topic topic, string category, string deck, Guid cardId);
        string ProcessTextForEdit(Topic topic, string category, string deck, Guid cardId, string stringToAnalyze);
        void SaveImages(Topic topic, string category, string deck, Guid cardId);
        void SaveTo(Topic topic, string category, string deck, Guid card, Guid imageId, byte[] bytes, string extension);
        void RemoveDirectory(string path);
    }
}
