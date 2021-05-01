using System;

namespace Flashcards.Application.Sessions
{
    public class SessionStateDto
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Deck { get; }
        public bool IsFinished { get; private set; }
        public SessionCardDto Card { get; private set; }

        public int TotalCount { get; }
        public int ActualCount { get; private set; }
        public int TotalAttempts { get; private set; }
        public int Percentage => (int)(((double) ActualCount / (double) TotalCount) * 100);

        public SessionStateDto(Guid userId, string deck, int totalCount)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Deck = deck;
            TotalCount = totalCount;
        }

        public void SetCard(SessionCardDto card)
        {
            TotalAttempts++;
            Card = card;
        }

        public void IncrementCounter()
        {
            ActualCount++;
        }

        public void Finish()
        {
            Card = null;
            IsFinished = true;
        }
    }
}
