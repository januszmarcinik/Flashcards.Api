using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Domain.Users
{
    public class LoginUserCommand : ICommand
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public Guid TokenId { get; private set; }

        public void SetTokenId(Guid tokenId)
        {
            TokenId = tokenId;
        }
    }
}
