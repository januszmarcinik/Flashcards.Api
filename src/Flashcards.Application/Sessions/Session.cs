using System;

namespace Flashcards.Application.Sessions
{
    public class Session : IEntity
    {
        protected Session() { }

        public Session(Guid deckId, Guid userId, DateTime date, decimal result)
        {
            Id = Guid.NewGuid();
            DeckId = deckId;
            UserId = userId;
            Result = result;
            Date = date;
        }

        public Guid Id { get; protected set; }
        public Guid DeckId { get; protected set; }
        public Guid UserId { get; protected set; }
        public decimal Result { get; protected set; }
        public DateTime Date { get; protected set; }

        public SessionDto ToDto()
            => new SessionDto(Date, Result);
    }
}
