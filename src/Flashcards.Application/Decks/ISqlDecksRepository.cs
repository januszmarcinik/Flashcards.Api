using System;
using System.Collections.Generic;

namespace Flashcards.Application.Decks
{
    public interface ISqlDecksRepository
    {
        Deck GetById(Guid id);
        Deck GetByName(string name);
        IEnumerable<Deck> GetAll();

        void Add(Deck deck);
        void Update(Deck deck);
        void Delete(Deck deck);
    }
}