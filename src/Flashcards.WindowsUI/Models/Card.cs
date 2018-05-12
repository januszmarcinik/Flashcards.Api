using System;
using Flashcards.WindowsUI.Infrastructure;

namespace Flashcards.WindowsUI.Models
{
    public class Card : IControlItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool Confirmed { get; set; }
        public Guid PreviousCardId { get; set; }
        public Guid NextCardId { get; set; }

        public string Display => Title;
    }
}
