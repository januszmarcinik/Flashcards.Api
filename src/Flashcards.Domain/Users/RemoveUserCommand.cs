using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Domain.Users
{
    public class RemoveUserCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }
    }
}
