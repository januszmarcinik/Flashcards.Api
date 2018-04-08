using Flashcards.Domain.Enums;
using Flashcards.Infrastructure.Commands.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.Infrastructure.Commands.Models.Categories
{
    public class AddCategoryCommandModel : ICommandModel
    {
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        [Required]
        public Topic? Topic { get; set; }
    }
}
