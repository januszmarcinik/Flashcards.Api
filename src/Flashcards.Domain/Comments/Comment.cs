using System;
using Flashcards.Core.Exceptions;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Users;

namespace Flashcards.Domain.Comments
{
    public class Comment : IEntity
    {
        public Guid Id { get; protected set; }
        public string Text { get; protected set; }
        public DateTime Date { get; protected set; }

        public virtual User User { get; protected set; }
        public Guid CardId { get; protected set; }

        protected Comment() { }

        public Comment(Guid cardId, string text)
        {
            Id = Guid.NewGuid();
            CardId = cardId;
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

        public CommentDto ToDto()
            => new CommentDto(Id, Text, Date, User.Email);
    }
}
