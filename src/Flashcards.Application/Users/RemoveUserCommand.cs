using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Application.Users
{
    public class RemoveUserCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }
    }
}
