using AutoMapper;
using Flashcards.Core.Exceptions;
using Flashcards.Domain.Data.Abstract;
using Flashcards.Domain.Extensions;
using Flashcards.Infrastructure.Dto.Cards;
using Flashcards.Infrastructure.Services.Abstract.Queries;
using System;
using System.Collections.Generic;
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
            => _mapper.Map<CardDto>(await _dbContext.Cards.FindAndEnsureExistsAsync(id, ErrorCode.CardDoesNotExist));

        public async Task<List<CardDto>> GetListAsync(string deckName)
        {
            var deck = _dbContext.Decks.SingleAndEnsureExists(x => x.Name == deckName, ErrorCode.DeckDoesNotExist);
            return await Task.FromResult(_mapper.Map<List<CardDto>>(deck.Cards));
        }
    }
}
