using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Application.Sessions
{
    public class ApplySessionCardCommand : ICommand
    {
        [Required]
        public Guid CardId { get; set; }

        [Required]
        public bool IsOk { get; set; }

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
