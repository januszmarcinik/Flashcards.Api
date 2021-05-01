using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Application.Users
{
    public class RegisterUserCommand : ICommand
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(32)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords doesn't match")]
        public string ConfirmPassword { get; set; }
    }
}
