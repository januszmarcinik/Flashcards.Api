using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;
using Newtonsoft.Json;

namespace Flashcards.Application.Cards
{
    public class AddCardCommand : ICommand
    {
        public Guid Id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        [JsonIgnore]
        public string Deck { get; set; }
        
        public AddCardCommand SetFromRoute(string deck)
        {
            Deck = deck;
            return this;
        }
    }
}
