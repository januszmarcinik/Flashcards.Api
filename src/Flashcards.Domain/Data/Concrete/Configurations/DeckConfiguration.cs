using Flashcards.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flashcards.Domain.Data.Concrete.Configurations
{
    internal class DeckConfiguration : IEntityTypeConfiguration<Deck>
    {
        public void Configure(EntityTypeBuilder<Deck> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(32);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Cards)
                .WithOne(x => x.Deck)
                .HasForeignKey("DeckId");
        }
    }
}
