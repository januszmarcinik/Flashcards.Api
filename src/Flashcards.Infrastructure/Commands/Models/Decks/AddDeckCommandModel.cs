using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Infrastructure.Commands.Abstract;

namespace Flashcards.Infrastructure.Commands.Models.Decks
{
    public class AddDeckCommandModel : ICommandModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string CategoryName { get; set; }

        public AddDeckCommandModel SetCategory(string categoryName)
        {
            CategoryName = categoryName;
            return this;
        }
    }
}
