using Flashcards.Domain.Sessions;
using Flashcards.Infrastructure.DataAccess;

namespace Flashcards.Infrastructure.Repositories
{
    internal class SessionsRepository : ISessionsRepository
    {
        private readonly EFContext _context;

        public SessionsRepository(EFContext context)
        {
            _context = context;
        }

        public void Add(Session session)
        {
            _context.Sessions.Add(session);
            _context.SaveChanges();
        }
    }
}
