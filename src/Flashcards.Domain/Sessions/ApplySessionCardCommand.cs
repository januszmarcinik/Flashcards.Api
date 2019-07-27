using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Domain.Sessions
{
    public class ApplySessionCardCommand : ICommand
    {
        [Required]
        public Guid CardId { get; set; }

        [Required]
        public SessionCardStatus Status { get; set; }

        public Guid UserId { get; private set; }
        public string Deck { get; private set; }

        public ApplySessionCardCommand SetFromRoute(Guid userId, string deck)
        {
            UserId = userId;
            Deck = deck;
            return this;
        }
    }
}
