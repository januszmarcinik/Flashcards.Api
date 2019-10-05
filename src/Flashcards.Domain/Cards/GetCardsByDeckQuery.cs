using System.Collections.Generic;
using Flashcards.Core;

namespace Flashcards.Domain.Cards
{
    public class GetCardsByDeckQuery : IQuery<IEnumerable<CardDto>>
    {
        public GetCardsByDeckQuery(string deck)
        {
            Deck = deck;
        }

        public string Deck { get; }
    }
}
