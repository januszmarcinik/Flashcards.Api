using Flashcards.Core.Exceptions;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Data.Abstract;
using System;

namespace Flashcards.Domain.Entities
{
    public class Card : Entity
    {
        public string Title { get; protected set; }
        public string Question { get; protected set; }
        public string Answer { get; protected set; }
        public virtual Deck Deck { get; protected set; }

        protected Card() { }

        public Card(string title, string question, string answer)
            : this(Guid.NewGuid(), title, question, answer) { }

        public Card(Guid id, string title, string question, string answer)
        {
            SetId(id);
            SetTitle(title);
            SetQuestion(question);
            SetAnswer(answer);
        }

        public void SetId(Guid id)
        {
            if (id.IsEmpty())
            {
                throw new FlashcardsException(ErrorCode.InvalidCardId);
            }

            Id = id;
        }

        public void SetTitle(string title)
        {
            if (title.IsEmpty())
            {
                throw new FlashcardsException(ErrorCode.InvalidCardTitle);
            }

            Title = title;
        }

        public void SetQuestion(string question)
        {
            if (question.IsEmpty())
            {
                throw new FlashcardsException(ErrorCode.InvalidCardQuestion);
            }

            Question = question;
        }

        public void SetAnswer(string answer)
        {
            if (answer.IsEmpty())
            {
                throw new FlashcardsException(ErrorCode.InvalidCardAnswer);
            }

            Answer = answer;
        }
    }
}
