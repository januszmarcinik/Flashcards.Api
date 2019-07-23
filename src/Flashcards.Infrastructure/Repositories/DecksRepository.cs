using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<DeckDto> GetAsync(string name)
            => await Task.FromResult(_dbContext.Decks.SingleAndEnsureExists(x => x.Name == name, ErrorCode.DeckDoesNotExist).ToDto());

        public async Task<List<DeckDto>> GetListAsync(string categoryName)
            => await Task.FromResult(_dbContext.Decks
                .Where(x => x.Category.Name == categoryName)
                .Select(x => x.ToDto())
                .ToList()
            );

        public async Task CreateAsync(string categoryName, string deckName, string description)
        {
            if (_dbContext.Decks.ExistsSingle(x => x.Name == deckName))
            {
                throw new FlashcardsException(ErrorCode.DeckAlreadyExist);
            }

            var category = _dbContext.Categories.SingleAndEnsureExists(x => x.Name == categoryName, ErrorCode.CategoryDoesNotExist);
            category.AddDeck(new Deck(deckName, description));
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var deckForRemove = await _dbContext.Decks.FindAsync(id);
            if (deckForRemove == null)
            {
                throw new FlashcardsException(ErrorCode.DeckDoesNotExist);
            }

            _dbContext.Decks.Remove(deckForRemove);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Guid deckId, string deckName, string description)
        {
            var deck = await _dbContext.Decks.FindAsync(deckId);
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
            await _dbContext.SaveChangesAsync();
        }
    }
}
