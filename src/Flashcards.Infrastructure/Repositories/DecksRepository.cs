using System;
using System.Collections.Generic;
using System.Linq;
using Flashcards.Core.Exceptions;
using Flashcards.Domain.Dto;
using Flashcards.Domain.Entities;
using Flashcards.Domain.Extensions;
using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.DataAccess;
using Flashcards.Infrastructure.Extensions;

namespace Flashcards.Infrastructure.Repositories
{
    internal class DecksRepository : IDecksRepository
    {
        private readonly EFContext _dbContext;

        public DecksRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DeckDto GetByName(string name)
            => _dbContext.Decks
                .SingleAndEnsureExists(x => x.Name == name, ErrorCode.DeckDoesNotExist)
                .ToDto();

        public List<DeckDto> GetByCategoryName(string categoryName)
            => _dbContext.Decks
                .Where(x => x.Category.Name == categoryName)
                .Select(x => x.ToDto())
                .ToList();

        public void Add(string categoryName, string deckName, string description)
        {
            if (_dbContext.Decks.ExistsSingle(x => x.Name == deckName))
            {
                throw new FlashcardsException(ErrorCode.DeckAlreadyExist);
            }

            var category = _dbContext.Categories.SingleAndEnsureExists(x => x.Name == categoryName, ErrorCode.CategoryDoesNotExist);
            category.AddDeck(new Deck(deckName, description));
            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var deckForRemove = _dbContext.Decks.Find(id);
            if (deckForRemove == null)
            {
                throw new FlashcardsException(ErrorCode.DeckDoesNotExist);
            }

            _dbContext.Decks.Remove(deckForRemove);
            _dbContext.SaveChanges();
        }

        public void Update(Guid deckId, string deckName, string description)
        {
            var deck = _dbContext.Decks.Find(deckId);
            if (deck == null)
            {
                throw new FlashcardsException(ErrorCode.DeckDoesNotExist);
            }

            if (_dbContext.Decks.ExistsSingleExceptFor(s => s.Name == deckName, deckId))
            {
                throw new FlashcardsException(ErrorCode.DeckAlreadyExist);
            }

            deck.SetName(deckName);
            deck.SetDescription(description);
            _dbContext.SaveChanges();
        }
    }
}
