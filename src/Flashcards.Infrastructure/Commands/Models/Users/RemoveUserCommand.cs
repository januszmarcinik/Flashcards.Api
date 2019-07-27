using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Infrastructure.Commands.Models.Users
{
    public class RemoveUserCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }
    }
}
