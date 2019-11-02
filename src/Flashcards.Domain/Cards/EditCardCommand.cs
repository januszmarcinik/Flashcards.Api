using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Domain.Cards
{
    public class EditCardCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public Guid UserId { get; set; }

        public string Deck { get; set; }

        public bool Confirmed { get; set; }

        public EditCardCommand SetFromRoute(string deck, Guid userId)
        {
            Deck = deck;
            UserId = userId;
            return this;
        }
    }
}
