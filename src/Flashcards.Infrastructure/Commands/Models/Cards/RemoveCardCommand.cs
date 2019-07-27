using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Infrastructure.Commands.Models.Cards
{
    public class RemoveCardCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }
    }
}
