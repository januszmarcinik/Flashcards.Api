using Flashcards.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Flashcards.Domain.Data.Abstract
{
    public interface IDbContext
    {
        DbSet<Card> Cards { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Deck> Decks { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
