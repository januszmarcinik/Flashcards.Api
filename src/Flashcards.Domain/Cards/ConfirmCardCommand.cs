using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Domain.Cards
{
    public class ConfirmCardCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }
    }
}
