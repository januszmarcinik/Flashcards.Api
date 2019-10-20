using System;

namespace Flashcards.Domain.Sessions
{
    public class SessionDto
    {
        public SessionDto(DateTime date, decimal result)
        {
            Date = date;
            Result = result;
        }

        public DateTime Date { get; }
        public decimal Result { get; }
    }
}
