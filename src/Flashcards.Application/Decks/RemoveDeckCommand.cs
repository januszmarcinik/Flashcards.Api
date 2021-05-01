using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Application.Decks
{
    public class RemoveDeckCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }
    }
}
