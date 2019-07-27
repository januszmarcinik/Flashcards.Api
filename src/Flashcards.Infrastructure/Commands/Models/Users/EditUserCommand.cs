using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Infrastructure.Commands.Models.Users
{
    public class EditUserCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(32)]
        public string Email { get; set; }
    }
}
