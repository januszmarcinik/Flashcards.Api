using System;
using System.Text.RegularExpressions;

namespace Flashcards.Domain.Cards
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

        public CardListItemDto ToListItemDto()
        {
            var question = Regex.Replace(Question, "<.*?>", string.Empty);
            if (question.Length > 100)
            {
                question = question.Remove(100);
            }

            return new CardListItemDto(Id, question, Confirmed);
        }

        public CardDto ToDto(string deckName, Guid previousCardId, Guid nextCardId)
            => new CardDto(Id, DeckId, deckName, Question, Answer, Confirmed, previousCardId, nextCardId);
    }
}
