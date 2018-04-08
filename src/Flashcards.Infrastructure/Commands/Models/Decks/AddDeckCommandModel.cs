using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Flashcards.Infrastructure.Commands.Abstract;

namespace Flashcards.Infrastructure.Commands.Models.Decks
{
    public class AddDeckCommandModel : ICommandModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
