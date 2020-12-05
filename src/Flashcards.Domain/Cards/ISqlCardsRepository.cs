using System;
using System.Collections.Generic;

namespace Flashcards.Domain.Cards
{
    public interface ISqlCardsRepository
    {
        Card GetById(Guid id);
        IEnumerable<Card> GetByDeck(Guid deckId);

        void Add(Card card);
        void Update(Card card);
        void Delete(Card card);
    }
}
