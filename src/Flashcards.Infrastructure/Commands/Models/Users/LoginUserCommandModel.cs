using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Infrastructure.Commands.Abstract;

namespace Flashcards.Infrastructure.Commands.Models.Users
{
    public class LoginUserCommandModel : ICommandModel
    {
        public Guid TokenId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
