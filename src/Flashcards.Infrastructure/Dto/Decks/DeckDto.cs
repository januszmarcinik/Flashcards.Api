using System;

namespace Flashcards.Infrastructure.Dto.Decks
{
    public class DeckDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
