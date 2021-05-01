using Flashcards.Application.Cards;
using Flashcards.Application.Comments;
using Flashcards.Application.Decks;
using Flashcards.Application.Sessions;
using Flashcards.Application.Users;
using Flashcards.Infrastructure.Sql.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Infrastructure.Sql
{
    public class EFContext : DbContext
    {
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Deck> Decks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }

        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CardConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new DeckConfiguration());
            builder.ApplyConfiguration(new SessionConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
