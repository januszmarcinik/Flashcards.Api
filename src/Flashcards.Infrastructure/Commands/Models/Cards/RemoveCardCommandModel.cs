using Flashcards.Infrastructure.Commands.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.Infrastructure.Commands.Models.Cards
{
    public class RemoveCardCommandModel : ICommandModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
