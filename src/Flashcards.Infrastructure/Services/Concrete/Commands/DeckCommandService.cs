using System;
using System.Threading.Tasks;
using AutoMapper;
using Flashcards.Core.Exceptions;
using Flashcards.Domain.Entities;
using Flashcards.Domain.Extensions;
using Flashcards.Infrastructure.DataAccess;
using Flashcards.Infrastructure.Extensions;
using Flashcards.Infrastructure.Services.Abstract.Commands;

namespace Flashcards.Infrastructure.Services.Concrete.Commands
{
    internal class DeckCommandService : IDeckCommandService
    {
        private readonly EFContext _dbContext;
        private readonly IMapper _mapper;

        public DeckCommandService(EFContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

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
