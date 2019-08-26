using System;
using System.Collections.Generic;

namespace Flashcards.Domain.Decks
{
    public interface IDecksRepository
    {
        Deck GetById(Guid id);
        Deck GetByName(string name);
        IEnumerable<Deck> GetAll();

        void Add(Deck deck);
        void Update(Deck deck);
        void Delete(Deck deck);
    }
}