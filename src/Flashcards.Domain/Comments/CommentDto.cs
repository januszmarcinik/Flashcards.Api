using System;

namespace Flashcards.Domain.Comments
{
    public class CommentDto
    {
        public CommentDto(Guid id, string text, DateTime date, string user)
        {
            Id = id;
            Text = text;
            Date = date;
            User = user;
        }

        public Guid Id { get; }
        public string Text { get; }
        public DateTime Date { get; }
        public string User { get; }
    }
}
