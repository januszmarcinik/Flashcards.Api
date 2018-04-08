using System;

namespace Flashcards.Infrastructure.Dto.Cards
{
    public class CardDto
    {
        public Guid Id { get; set; }
        public string Title { get; protected set; }
        public string Question { get; protected set; }
        public string Answer { get; protected set; }
    }
}
