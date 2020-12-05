using System;

namespace Flashcards.Domain.Cards
{
    public interface INoSqlCardsRepository
    {
        CardDto GetById(Guid id);
        
        void Update(CardDto card);
    }
}