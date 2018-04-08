using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Flashcards.Core.Exceptions;
using Flashcards.Domain.Data.Abstract;
using Flashcards.Domain.Extensions;
using Flashcards.Infrastructure.Dto.Decks;
using Flashcards.Infrastructure.Services.Abstract.Queries;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Infrastructure.Services.Concrete.Queries
{
    internal class DeckQueryService : IDeckQueryService
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeckQueryService(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<DeckDto>> GetListAsync()
            => _mapper.Map<List<DeckDto>>(await _dbContext.Decks.ToListAsync());

        public async Task<DeckDto> GetAsync(Guid id)
            => _mapper.Map<DeckDto>(await _dbContext.Decks.FindAndEnsureExistsAsync(id, ErrorCode.DeckDoesNotExist));

        public async Task<DeckDto> GetAsync(string name)
            => await Task.FromResult(_mapper.Map<DeckDto>(_dbContext.Decks.SingleAndEnsureExists(x => x.Name == name, ErrorCode.DeckDoesNotExist)));

        public async Task<List<DeckDto>> GetListAsync(string categoryName)
            => await Task.FromResult(_mapper.Map<List<DeckDto>>(_dbContext.Decks.Where(x => x.Category.Name == categoryName)));
    }
}
