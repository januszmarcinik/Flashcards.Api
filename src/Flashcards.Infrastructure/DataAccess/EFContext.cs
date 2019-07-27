﻿using Flashcards.Domain.Entities;
using Flashcards.Infrastructure.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Infrastructure.DataAccess
{
    public class EFContext : DbContext
    {
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Deck> Decks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {
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