using System;

namespace Flashcards.Application.Sessions
{
    public class SessionCardDto
    {
        public Guid CardId { get; }
        public string Question { get; }
        public string Answer { get; }

        public SessionCardDto(Guid cardId, string answer, string question)
        {
            CardId = cardId;
            Answer = answer;
            Question = question;
        }
    }
}
