using System;
using Flashcards.Core;

namespace Flashcards.Domain.Cards
{
    public class CardEditedEvent : IEvent
    {
        public CardEditedEvent(Guid cardId)
        {
            CardId = cardId;
        }

        public Guid CardId { get; }
    }
}