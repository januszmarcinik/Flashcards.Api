using System;

namespace Flashcards.WindowsUI.Models.Sessions
{
    public class ApplySessionCardCommand
    {
        public Guid CardId { get; }
        public SessionCardStatus Status { get; }

        public ApplySessionCardCommand(Guid cardId, SessionCardStatus status)
        {
            CardId = cardId;
            Status = status;
        }
    }
}
