using System;
using System.Collections.Generic;
using Flashcards.Application.Decks;
using Flashcards.Infrastructure.DataAccess;
using MongoDB.Driver;

namespace Flashcards.Infrastructure.Mongo.Repositories
{
    internal class NoSqlDecksRepository : INoSqlDecksRepository
    {
        private readonly MongoDbContext _dbContext;

        public NoSqlDecksRepository(MongoDbContext dbContext) => 
            _dbContext = dbContext;

        public DeckDto GetById(Guid id) => 
            _dbContext.Decks
                .Find(x => x.Id == id)
                .SingleOrDefault();

        public DeckDto GetByName(string name) => 
            _dbContext.Decks
                .Find(x => x.Name == name)
                .SingleOrDefault();
        
        public IEnumerable<DeckDto> GetAll() =>
            _dbContext.Decks
                .Find(x => true)
                .SortBy(x => x.Name)
                .ToList();

        public void Add(DeckDto deck) => 
            _dbContext.Decks.InsertOne(deck);

        public void Update(DeckDto deck) => 
            _dbContext.Decks.ReplaceOne(x => x.Id == deck.Id, deck);

        public void UpdateCards(Guid deckId, IEnumerable<DeckDto.Card> cards)
        {
            var update = Builders<DeckDto>.Update.Set(_ => _.Cards, cards);
            _dbContext.Decks.UpdateOne(x => x.Id == deckId, update);
        }

        public void Remove(Guid id) => 
            _dbContext.Decks.DeleteOne(x => x.Id == id);
    }
}