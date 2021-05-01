using System;
using System.Collections.Generic;

namespace Flashcards.Application.Decks
{
    public interface INoSqlDecksRepository
    {
        DeckDto GetById(Guid id);
        
        DeckDto GetByName(string name);

        IEnumerable<DeckDto> GetAll();

        void Add(DeckDto deck);
        
        void Update(DeckDto deck);

        void UpdateCards(Guid deckId, IEnumerable<DeckDto.Card> cards);

        void Remove(Guid id);
    }
}