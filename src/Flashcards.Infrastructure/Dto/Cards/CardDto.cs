using System;

namespace Flashcards.Infrastructure.Dto.Cards
{
    public class CardDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public Guid PreviousCardId { get; set; }
        public Guid NextCardId { get; set; }
    }
}
