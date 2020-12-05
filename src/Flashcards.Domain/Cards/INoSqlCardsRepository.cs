using System;
using System.Collections.Generic;

namespace Flashcards.Domain.Cards
{
    public interface INoSqlCardsRepository
    {
        CardDto GetById(Guid id);

        CardDto GetLastByDeck(Guid deckId);

        IEnumerable<CardDto> GetByDeckName(string deckName);

        void Add(CardDto card);
        
        void Update(CardDto card);

        void Remove(Guid id);
    }
}