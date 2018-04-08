using System.Threading.Tasks;
using AutoMapper;
using Flashcards.Core.Exceptions;
using Flashcards.Domain.Data.Abstract;
using Flashcards.Domain.Entities;
using Flashcards.Domain.Extensions;
using Flashcards.Infrastructure.Services.Abstract.Commands;

namespace Flashcards.Infrastructure.Services.Concrete.Commands
{
    internal class DeckCommandService : IDeckCommandService
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeckCommandService(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(string categoryName, string deckName)
        {
            if (_dbContext.Decks.ExistsSingle(x => x.Name == deckName))
            {
                throw new FlashcardsException(ErrorCode.DeckAlreadyExist);
            }

            var category = _dbContext.Categories.SingleAndEnsureExists(x => x.Name == categoryName, ErrorCode.CategoryDoesNotExist);
            category.AddDeck(new Deck(deckName));
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
