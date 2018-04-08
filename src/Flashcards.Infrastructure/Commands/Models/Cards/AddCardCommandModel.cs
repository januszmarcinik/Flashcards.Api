using Flashcards.Infrastructure.Commands.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.Infrastructure.Commands.Models.Cards
{
    public class AddCardCommandModel : ICommandModel
    {
        public Guid Id { get; set; }

        public string Deck { get; set; }

        [Required]
        [MaxLength(32)]
        public string Title { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public AddCardCommandModel SetDeck(string deck)
        {
            Deck = deck;
            return this;
        }
    }
}
