using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Application.Cards
{
    public class RemoveCardCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }
    }
}
