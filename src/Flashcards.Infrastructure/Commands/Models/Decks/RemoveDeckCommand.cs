using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Infrastructure.Commands.Models.Decks
{
    public class RemoveDeckCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }
    }
}
