using System;

namespace Flashcards.WindowsUI.Models.Sessions
{
    public class SessionState
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Deck { get; set; }
        public bool IsFinished { get; set; }
        public SessionCard Card { get; set; }

        public int TotalCount { get; set; }
        public int ActualCount { get; set; }
        public int Percentage { get; set; }
    }
}
