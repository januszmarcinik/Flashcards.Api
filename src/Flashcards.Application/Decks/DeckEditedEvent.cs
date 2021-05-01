using System;
using Flashcards.Core;

namespace Flashcards.Application.Decks
{
    public class DeckEditedEvent : IEvent
    {
        public DeckEditedEvent(Guid deckId)
        {
            DeckId = deckId;
        }

        public Guid DeckId { get; }
    }
}