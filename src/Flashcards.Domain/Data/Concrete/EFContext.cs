using Flashcards.Domain.Data.Abstract;
using Flashcards.Domain.Data.Concrete.Configurations;
using Flashcards.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Domain.Data.Concrete
{
    internal class EFContext : DbContext, IDbContext
    {
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Deck> Decks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public EFContext(string databaseName)
            : base(new DbContextOptionsBuilder<EFContext>().UseInMemoryDatabase(databaseName).Options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CardConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new DeckConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
