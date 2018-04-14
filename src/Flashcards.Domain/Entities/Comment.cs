using Flashcards.Core.Exceptions;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Data.Abstract;
using System;

namespace Flashcards.Domain.Entities
{
    public class Comment : Entity
    {
        public string Text { get; protected set; }
        public DateTime Date { get; protected set; }

        public virtual User User { get; protected set; }
        public virtual Card Card { get; protected set; }

        protected Comment() { }

        public Comment(string text)
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
            SetText(text);
        }

        public void SetText(string text)
        {
            if (text.IsEmpty())
            {
                throw new FlashcardsException(ErrorCode.InvalidCommentText);
            }

            Text = text;
        }
    }
}
