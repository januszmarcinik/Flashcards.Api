using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;
using Flashcards.Domain.Enums;

namespace Flashcards.Infrastructure.Commands.Models.Cards
{
    public class EditCardCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public Guid UserId { get; set; }

        public Topic Topic { get; set; }
        public string Category { get; set; }
        public string Deck { get; set; }

        public EditCardCommand SetFromRoute(Topic topic, string category, string deck, Guid userId)
        {
            Topic = topic;
            Category = category;
            Deck = deck;
            UserId = userId;
            return this;
        }
    }
}
