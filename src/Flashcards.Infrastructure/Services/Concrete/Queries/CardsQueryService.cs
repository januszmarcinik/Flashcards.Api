using AutoMapper;
using Flashcards.Core.Exceptions;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Data.Abstract;
using Flashcards.Domain.Extensions;
using Flashcards.Infrastructure.Dto.Cards;
using Flashcards.Infrastructure.Dto.Comments;
using Flashcards.Infrastructure.Services.Abstract.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Concrete.Queries
{
    internal class CardsQueryService : ICardsQueryService
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbContext;

        public CardsQueryService(IMapper mapper, IDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<CardDto> GetAsync(Guid id)
        {
            var current = await _dbContext.Cards.FindAndEnsureExistsAsync(id, ErrorCode.CardDoesNotExist);
            var dto = _mapper.Map<CardDto>(current);

            var ids = current.Deck.Cards
                .OrderBy(x => x.Title)
                .Select(x => x.Id)
                .ToList();

            dto.NextCardId = ids.NextOrDefault(current.Id);
            dto.PreviousCardId = ids.PreviousOrDefault(current.Id);

            return dto;
        }

        public async Task<List<CardDto>> GetListAsync(string deckName)
        {
            var deck = _dbContext.Decks.SingleAndEnsureExists(x => x.Name == deckName, ErrorCode.DeckDoesNotExist);
            var cards = deck.Cards.OrderBy(x => x.Title);
            return await Task.FromResult(_mapper.Map<List<CardDto>>(cards));
        }
    }
}
