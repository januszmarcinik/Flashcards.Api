using Flashcards.Domain.Enums;
using Flashcards.Infrastructure.Commands.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.Infrastructure.Commands.Models.Categories
{
    public class EditCategoryCommandModel : ICommandModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        [Required]
        public Topic? Topic { get; set; }
    }
}
