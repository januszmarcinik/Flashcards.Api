using System;
using System.Collections.Generic;
using System.Linq;
using Flashcards.Domain.Decks;

namespace Flashcards.Infrastructure.Sql.Repositories
{
    internal class SqlDecksRepository : ISqlDecksRepository
    {
        private readonly EFContext _dbContext;

        public SqlDecksRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Deck GetById(Guid id)
            => _dbContext.Decks.SingleOrDefault(x => x.Id == id);

        public Deck GetByName(string name)
            => _dbContext.Decks.SingleOrDefault(x => x.Name == name);

        public IEnumerable<Deck> GetAll()
            => _dbContext.Decks.ToList();

        public void Add(Deck deck)
        {
            _dbContext.Decks.Add(deck);
            _dbContext.SaveChanges();
        }

        public void Update(Deck deck)
        {
            _dbContext.Decks.Update(deck);
            _dbContext.SaveChanges();
        }

        public void Delete(Deck deck)
        {
            _dbContext.Decks.Remove(deck);
            _dbContext.SaveChanges();
        }
    }
}
