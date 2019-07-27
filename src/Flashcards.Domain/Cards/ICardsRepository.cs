using System;
using System.Collections.Generic;

namespace Flashcards.Domain.Cards
{
    public interface ICardsRepository
    {
        CardDto GetById(Guid id);
        List<CardDto> GetByDeckName(string deckName);

        void Add(string deckName, string title, string question, string answer);
        void Update(Guid cardId, string title, string question, string answer);
        void Delete(Guid id);
        void Confirm(Guid id);
    }
}
