using System;
using System.Collections.Generic;
using Flashcards.Core;

namespace Flashcards.Application.Sessions
{
    public class GetSessionsQuery : IQuery<IEnumerable<SessionDto>>
    {
        public GetSessionsQuery(Guid userId, string deckName)
        {
            UserId = userId;
            DeckName = deckName;
        }

        public Guid UserId { get; }
        public string DeckName { get; }
    }
}
