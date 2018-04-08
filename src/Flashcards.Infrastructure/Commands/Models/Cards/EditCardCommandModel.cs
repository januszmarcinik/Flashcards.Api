using Flashcards.Infrastructure.Commands.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.Infrastructure.Commands.Models.Cards
{
    public class EditCardCommandModel : ICommandModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Title { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}
