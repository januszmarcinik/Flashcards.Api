using System;
using Flashcards.Domain.Cards;
using Flashcards.Infrastructure.DataAccess;
using MongoDB.Driver;

namespace Flashcards.Infrastructure.Repositories
{
    internal class NoSqlCardsRepository : INoSqlCardsRepository
    {
        private readonly MongoDbContext _dbContext;

        public NoSqlCardsRepository(MongoDbContext dbContext) => 
            _dbContext = dbContext;

        public CardDto GetById(Guid id) => 
            _dbContext.Cards.Find(x => x.Id == id).SingleOrDefault();

        public void Update(CardDto card) => 
            _dbContext.Cards.ReplaceOne(x => x.Id == card.Id, card);
    }
}