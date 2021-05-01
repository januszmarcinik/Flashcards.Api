using System;
using Flashcards.Core;

namespace Flashcards.Application.Cards
{
    public class CardAddedEvent : IEvent
    {
        public CardAddedEvent(Guid cardId)
        {
            CardId = cardId;
        }

        public Guid CardId { get; }
    }
}