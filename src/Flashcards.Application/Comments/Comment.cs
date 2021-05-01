using System;

namespace Flashcards.Application.Comments
{
    public class Comment : IEntity
    {
        public Guid Id { get; protected set; }
        public string Text { get; set; }
        public DateTime Date { get; protected set; }

        public Guid UserId { get; protected set; }
        public Guid CardId { get; protected set; }

        protected Comment() { }

        public Comment(Guid cardId, Guid userId, string text)
        {
            Id = Guid.NewGuid();
            CardId = cardId;
            UserId = userId;
            Date = DateTime.Now;
            Text = text;
        }

        public CommentDto ToDto(string userEmail)
            => new CommentDto(Id, Text, Date, userEmail);
    }
}
