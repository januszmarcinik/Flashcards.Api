using System;
using Flashcards.Core;

namespace Flashcards.Domain.Decks
{
    public class DeckAddedEvent : IEvent
    {
        public DeckAddedEvent(Guid deckId)
        {
            DeckId = deckId;
        }

        public Guid DeckId { get; }
    }
}