using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Flashcards.Infrastructure.Commands.Abstract;

namespace Flashcards.Infrastructure.Commands.Models.Decks
{
    public class RemoveDeckCommandModel : ICommandModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
