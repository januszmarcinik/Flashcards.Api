using System;
using System.Collections.Generic;

namespace Flashcards.Application.Decks
{
    public class DeckDto
    {
        public DeckDto(Guid id, string name, string description, IEnumerable<Card> cards)
        {
            Id = id;
            Name = name;
            Description = description;
            Cards = cards;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public IEnumerable<Card> Cards { get; }
        
        public class Card
        {
            public Card(Guid id,  string question, bool confirmed)
            {
                Id = id;
                Question = question;
                Confirmed = confirmed;
            }

            public Guid Id { get; }
            public string Question { get; }
            public bool Confirmed { get; }
        }
    }
}
