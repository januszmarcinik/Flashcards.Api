using System;
using Flashcards.Core;

namespace Flashcards.Application.Sessions
{
    public class GetSessionQuery : IQuery<SessionStateDto>
    {
        public Guid UserId { get; }
        public string Deck { get; }

        public GetSessionQuery(Guid userId, string deck)
        {
            UserId = userId;
            Deck = deck;
        }
    }
}
