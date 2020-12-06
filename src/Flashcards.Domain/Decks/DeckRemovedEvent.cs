using System;
using Flashcards.Core;

namespace Flashcards.Domain.Decks
{
    public class DeckRemovedEvent : IEvent
    {
        public DeckRemovedEvent(Guid deckId)
        {
            DeckId = deckId;
        }

        public Guid DeckId { get; }
    }
}