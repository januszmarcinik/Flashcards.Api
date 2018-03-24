using Flashcards.Infrastructure.Commands.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.Infrastructure.Commands.Models.Users
{
    public class RemoveUserCommandModel : ICommandModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
