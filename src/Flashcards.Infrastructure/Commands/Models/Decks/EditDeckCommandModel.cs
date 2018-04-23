using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Flashcards.Infrastructure.Commands.Abstract;

namespace Flashcards.Infrastructure.Commands.Models.Decks
{
    public class EditDeckCommandModel : ICommandModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(32)]
        [RegularExpression(@"([A-Za-z\d\-]+)", ErrorMessage = "Name can contains only letters from a-z and \"-\" not case sensitive.")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
