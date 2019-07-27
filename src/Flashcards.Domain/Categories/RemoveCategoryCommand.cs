using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Domain.Categories
{
    public class RemoveCategoryCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }
    }
}
