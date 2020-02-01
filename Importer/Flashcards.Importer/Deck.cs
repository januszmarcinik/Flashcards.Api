using System;
using System.Collections.Generic;

namespace Flashcards.Importer
{
    public class Deck
    {
        private readonly List<Card> _cards;
        
        public Deck(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            _cards = new List<Card>();
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public IEnumerable<Card> Cards => _cards;

        public void AddCard(Card card)
            => _cards.Add(card);
    }
}