using System;

namespace Flashcards.Infrastructure.Dto.Sessions
{
    public class SessionCardDto
    {
        public Guid CardId { get; }
        public string Title { get; }
        public string Question { get; }
        public string Answer { get; }

        public SessionCardDto(Guid cardId, string title, string answer, string question)
        {
            CardId = cardId;
            Title = title;
            Answer = answer;
            Question = question;
        }
    }
}
