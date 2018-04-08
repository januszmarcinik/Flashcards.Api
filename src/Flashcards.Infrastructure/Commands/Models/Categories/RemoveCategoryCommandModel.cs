using Flashcards.Infrastructure.Commands.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.Infrastructure.Commands.Models.Categories
{
    public class RemoveCategoryCommandModel : ICommandModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
