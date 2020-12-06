using System;

namespace Flashcards.Domain.Cards
{
    public interface ISqlCardsRepository
    {
        Card GetById(Guid id);
        
        void Add(Card card);
        
        void Update(Card card);
        
        void Delete(Card card);
    }
}
