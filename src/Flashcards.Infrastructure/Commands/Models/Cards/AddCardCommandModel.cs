using Flashcards.Domain.Enums;
using Flashcards.Infrastructure.Commands.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.Infrastructure.Commands.Models.Cards
{
    public class AddCardCommandModel : ICommandModel
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

        public AddCardCommandModel SetFromRoute(Topic topic, string category, string deck)
        {
            Topic = topic;
            Category = category;
            Deck = deck;
            return this;
        }
    }
}
