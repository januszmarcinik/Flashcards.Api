using System;
using System.Collections.Generic;
using System.Text;
using Flashcards.Infrastructure.Dto.Cards;

namespace Flashcards.Infrastructure.Dto.Decks
{
    public class DeckWithCardsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CardDto> Cards { get; set; }
    }
}
