using System;
using Flashcards.WindowsUI.Infrastructure;

namespace Flashcards.WindowsUI.Models
{
    public class Deck : IControlItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Display
            => $"{Name} ({Description})";
    }
}
