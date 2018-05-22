using System;

namespace Flashcards.WindowsUI.Models.Sessions
{
    public class SessionCard
    {
        public Guid CardId { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
