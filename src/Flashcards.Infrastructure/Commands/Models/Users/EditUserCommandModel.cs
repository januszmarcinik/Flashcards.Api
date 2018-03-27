using Flashcards.Infrastructure.Commands.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.Infrastructure.Commands.Models.Users
{
    public class EditUserCommandModel : ICommandModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(32)]
        public string Email { get; set; }
    }
}
