using System;

namespace Flashcards.Domain.Cards
{
    public interface IImagesService
    {
        string GetVirtualPath(string deck);
        string GetVirtualPath(string deck, Guid cardId);
        string GetVirtualPath(string deck, Guid cardId, Guid imageId, string extensions);
        string GetPhysicalPath(string deck, Guid cardId);
        string ProcessTextForEdit(string deck, Guid cardId, string stringToAnalyze);
        void SaveImages(string deck, Guid cardId);
        void SaveTo(string deck, Guid card, Guid imageId, byte[] bytes, string extension);
        void RemoveDirectory(string path);
    }
}
