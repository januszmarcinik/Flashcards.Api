using System;
using System.Collections.Generic;
using Flashcards.Domain.Dto;

namespace Flashcards.Domain.Repositories
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