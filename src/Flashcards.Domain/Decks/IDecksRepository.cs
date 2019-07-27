using System;
using System.Collections.Generic;

namespace Flashcards.Domain.Decks
{
    public interface IDecksRepository
    {
        DeckDto GetByName(string name);
        List<DeckDto> GetByCategoryName(string categoryName);

        void Add(string categoryName, string deckName, string description);
        void Delete(Guid id);
        void Update(Guid deckId, string deckName, string description);
    }
}