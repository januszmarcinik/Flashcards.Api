using System;
using System.Collections.Generic;

namespace Flashcards.Domain.Sessions
{
    public interface ISessionsRepository
    {
        IEnumerable<Session> GetBy(Guid deckId, Guid userId);

        void Add(Session session);
    }
}
