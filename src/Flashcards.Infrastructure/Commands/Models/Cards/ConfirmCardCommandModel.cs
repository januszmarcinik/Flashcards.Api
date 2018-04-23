using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Infrastructure.Commands.Abstract;

namespace Flashcards.Infrastructure.Commands.Models.Cards
{
    public class ConfirmCardCommandModel : ICommandModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
