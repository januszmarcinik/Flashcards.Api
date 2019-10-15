using Flashcards.Domain.Cards;
using Flashcards.Domain.Decks;
using Flashcards.Domain.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flashcards.Infrastructure.DataAccess.Configurations
{
    internal class DeckConfiguration : IEntityTypeConfiguration<Deck>
    {
        public void Configure(EntityTypeBuilder<Deck> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(32);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany<Card>()
                .WithOne()
                .HasForeignKey(x => x.DeckId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<Session>()
                .WithOne()
                .HasForeignKey(x => x.DeckId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
