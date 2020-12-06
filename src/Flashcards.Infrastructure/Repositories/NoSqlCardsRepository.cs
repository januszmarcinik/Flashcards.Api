using System;
using System.Collections.Generic;
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
            _dbContext.Cards
                .Find(x => x.Id == id)
                .SingleOrDefault();
        
        public CardDto GetLastByDeck(Guid deckId) => 
            _dbContext.Cards
                .Find(x => x.DeckId == deckId && x.NextCardId == Guid.Empty)
                .SingleOrDefault();
        
        public IEnumerable<CardDto> GetByDeckName(string deckName) =>
            _dbContext.Cards
                .Find(x => x.DeckName == deckName)
                .ToList();

        public void Add(CardDto card) => 
            _dbContext.Cards.InsertOne(card);

        public void Update(CardDto card) => 
            _dbContext.Cards.ReplaceOne(x => x.Id == card.Id, card);

        public void Remove(Guid id) => 
            _dbContext.Cards.DeleteOne(x => x.Id == id);

        public void RemoveByDeck(Guid deckId) => 
            _dbContext.Cards.DeleteMany(x => x.DeckId == deckId);
    }
}