using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Infrastructure.Commands.Abstract;

namespace Flashcards.Infrastructure.Commands.Models.Decks
{
    public class AddDeckCommandModel : ICommandModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(32)]
        [RegularExpression(@"([A-Za-z\d\-]+)", ErrorMessage = "Name can contains only letters from a-z and \"-\" not case sensitive.")]
        public string Name { get; set; }

        public string CategoryName { get; set; }
        public string Description { get; set; }

        public AddDeckCommandModel SetCategory(string categoryName)
        {
            CategoryName = categoryName;
            return this;
        }
    }
}
