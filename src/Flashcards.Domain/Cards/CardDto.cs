using System;

namespace Flashcards.Domain.Cards
{
    public class CardDto
    {
        public CardDto(Guid id, string question, string answer, bool confirmed, Guid previousCardId, Guid nextCardId)
        {
            Id = id;
            Question = question;
            Answer = answer;
            Confirmed = confirmed;
            PreviousCardId = previousCardId;
            NextCardId = nextCardId;
        }

        public Guid Id { get; }
        public string Question { get; }
        public string Answer { get; }
        public bool Confirmed { get; }
        public Guid PreviousCardId { get; }
        public Guid NextCardId { get; }
    }
}
