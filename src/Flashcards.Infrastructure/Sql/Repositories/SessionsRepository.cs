using System;
using System.Collections.Generic;
using System.Linq;
using Flashcards.Domain.Sessions;

namespace Flashcards.Infrastructure.Sql.Repositories
{
    internal class SessionsRepository : ISessionsRepository
    {
        private readonly EFContext _context;

        public SessionsRepository(EFContext context)
        {
            _context = context;
        }

        public IEnumerable<Session> GetBy(Guid deckId, Guid userId)
            => _context.Sessions
                .Where(x => x.UserId == userId)
                .Where(x => x.DeckId == deckId)
                .OrderByDescending(x => x.Date)
                .ToList();

        public void Add(Session session)
        {
            _context.Sessions.Add(session);
            _context.SaveChanges();
        }
    }
}
