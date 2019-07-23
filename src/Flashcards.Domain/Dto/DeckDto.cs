using System;

namespace Flashcards.Domain.Dto
{
    public class DeckDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
