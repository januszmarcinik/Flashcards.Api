using Flashcards.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Flashcards.Domain.Data.Abstract
{
    interface IDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Deck> Decks { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
