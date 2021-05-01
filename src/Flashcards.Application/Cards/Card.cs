using System;

namespace Flashcards.Application.Cards
{
    public class Card : IEntity
    {
        public Guid Id { get; protected set; }
        public Guid DeckId { get; protected set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool Confirmed { get; set; }

        protected Card() { }

        public Card(Guid deckId, string question, string answer)
        {
            Id = Guid.NewGuid();
            DeckId = deckId;
            Question = question;
            Answer = answer;
            Confirmed = false;
        }

        public CardDto ToDto(string deckName, Guid previousCardId, Guid nextCardId)
            => new CardDto(Id, DeckId, deckName, Question, Answer, Confirmed, previousCardId, nextCardId);
    }
}
