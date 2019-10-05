using System;

namespace Flashcards.Domain.Cards
{
    public class Card : IEntity
    {
        public Guid Id { get; protected set; }
        public Guid DeckId { get; protected set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool Confirmed { get; protected set; }

        protected Card() { }

        public Card(Guid deckId, string title, string question, string answer)
        {
            Id = Guid.NewGuid();
            DeckId = deckId;
            Title = title;
            Question = question;
            Answer = answer;
            Confirmed = false;
        }

        public void ToggleConfirmed()
        {
            Confirmed = !Confirmed;
        }

        public CardDto ToDto()
            => ToDto(Guid.Empty, Guid.Empty);

        public CardDto ToDto(Guid previousCardId, Guid nextCardId)
            => new CardDto(Id, Title, Question, Answer, Confirmed, previousCardId, nextCardId);
    }
}
