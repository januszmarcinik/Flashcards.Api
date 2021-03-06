﻿using System;
using System.Linq;
using Flashcards.Application.Cards;

namespace Flashcards.Infrastructure.Sql.Repositories
{
    internal class SqlCardsRepository : ISqlCardsRepository
    {
        private readonly EFContext _dbContext;

        public SqlCardsRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Card GetById(Guid id)
            => _dbContext.Cards.SingleOrDefault(x => x.Id == id);

        public void Add(Card card)
        {
            _dbContext.Cards.Add(card);
            _dbContext.SaveChanges();
        }

        public void Update(Card card)
        {
            _dbContext.Cards.Update(card);
            _dbContext.SaveChanges();
        }

        public void Delete(Card card)
        {
            _dbContext.Cards.Remove(card);
            _dbContext.SaveChanges();
        }
    }
}
