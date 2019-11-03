using System;

namespace Flashcards.Domain.Cards
{
    public class CardListItemDto
    {
        public CardListItemDto(Guid id,  string question, bool confirmed)
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
