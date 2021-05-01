using System;
using Flashcards.Core;

namespace Flashcards.Application.Decks
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