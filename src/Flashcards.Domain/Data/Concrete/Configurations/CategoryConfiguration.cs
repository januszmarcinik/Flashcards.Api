using Flashcards.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flashcards.Domain.Data.Concrete.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(32);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Decks)
                .WithOne(x => x.Category)
                .HasForeignKey("CategoryId");
        }
    }
}
