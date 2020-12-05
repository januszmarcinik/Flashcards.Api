using System;
using Flashcards.Core;

namespace Flashcards.Domain.Cards
{
    public class CardRemovedEvent : IEvent
    {
        public CardRemovedEvent(Guid cardId)
        {
            CardId = cardId;
        }

        public Guid CardId { get; }
    }
}