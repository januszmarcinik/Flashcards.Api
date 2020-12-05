using System;

namespace Flashcards.Domain.Cards
{
    public class CardDto
    {
        public CardDto(Guid id, Guid deckId, string question, string answer, bool confirmed, Guid previousCardId, Guid nextCardId)
        {
            Id = id;
            DeckId = deckId;
            Question = question;
            Answer = answer;
            Confirmed = confirmed;
            PreviousCardId = previousCardId;
            NextCardId = nextCardId;
        }

        public Guid Id { get; }
        public Guid DeckId { get; }
        public string Question { get; }
        public string Answer { get; }
        public bool Confirmed { get; }
        public Guid PreviousCardId { get; }
        public Guid NextCardId { get; }
        
        public CardDto Recreate(Guid previousCardId, Guid nextCardId) =>
            new CardDto(Id, DeckId, Question, Answer, Confirmed, previousCardId, nextCardId);
    }
}
