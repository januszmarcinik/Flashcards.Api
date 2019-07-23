using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Domain.Dto;
using Flashcards.Domain.Enums;
using Flashcards.Infrastructure.Commands.Abstract;

namespace Flashcards.Infrastructure.Commands.Models.Sessions
{
    public class ApplySessionCardCommandModel : ICommandModel
    {
        [Required]
        public Guid CardId { get; set; }

        [Required]
        public SessionCardStatus Status { get; set; }

        public Guid UserId { get; private set; }
        public string Deck { get; private set; }

        public ApplySessionCardCommandModel SetFromRoute(Guid userId, string deck)
        {
            UserId = userId;
            Deck = deck;
            return this;
        }
    }
}
