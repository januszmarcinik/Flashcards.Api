using Flashcards.Domain.Enums;
using Flashcards.Infrastructure.Commands.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.Infrastructure.Commands.Models.Users
{
    public class RegisterUserCommandModel : ICommandModel
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Email { get; set; }

        [Required]
        public Role Role { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
