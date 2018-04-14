using System;

namespace Flashcards.Infrastructure.Dto.Comments
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }
    }
}
