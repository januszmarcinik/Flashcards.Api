using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;
using Flashcards.Domain.Categories;

namespace Flashcards.Domain.Cards
{
    public class AddCardCommand : ICommand
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public Topic Topic { get; set; }
        public string Category { get; set; }
        public string Deck { get; set; }

        public AddCardCommand SetFromRoute(Topic topic, string category, string deck)
        {
            Topic = topic;
            Category = category;
            Deck = deck;
            return this;
        }
    }
}
