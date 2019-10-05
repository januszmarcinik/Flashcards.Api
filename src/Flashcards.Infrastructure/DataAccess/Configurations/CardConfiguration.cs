using Flashcards.Domain.Cards;
using Flashcards.Domain.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flashcards.Infrastructure.DataAccess.Configurations
{
    internal class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(128);

            builder.HasMany<Comment>()
                .WithOne()
                .HasForeignKey(x => x.CardId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
