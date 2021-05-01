using System;
using System.Collections.Generic;

namespace Flashcards.Application.Decks
{
    public class Deck : IEntity
    {
        public Guid Id { get; protected set; }
        public string Name { get; set; }
        public string Description { get; set; }

        protected Deck() { }

        public Deck(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public DeckDto ToDto(IEnumerable<DeckDto.Card> cards)
            => new DeckDto(Id, Name, Description, cards);
    }
}
