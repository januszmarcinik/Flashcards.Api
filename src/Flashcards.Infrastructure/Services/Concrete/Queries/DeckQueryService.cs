using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Core.Exceptions;
using Flashcards.Domain.Dto;
using Flashcards.Infrastructure.DataAccess;
using Flashcards.Infrastructure.Extensions;
using Flashcards.Infrastructure.Services.Abstract.Queries;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Infrastructure.Services.Concrete.Queries
{
    internal class DeckQueryService : IDeckQueryService
    {
        private readonly EFContext _dbContext;

        public DeckQueryService(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DeckDto>> GetListAsync()
            => await _dbContext.Decks.Select(x => x.ToDto()).ToListAsync();

        public async Task<DeckDto> GetAsync(Guid id)
            => (await _dbContext.Decks.FindAndEnsureExistsAsync(id, ErrorCode.DeckDoesNotExist)).ToDto();

        public async Task<DeckDto> GetAsync(string name)
            => await Task.FromResult(_dbContext.Decks.SingleAndEnsureExists(x => x.Name == name, ErrorCode.DeckDoesNotExist).ToDto());

        public async Task<List<DeckDto>> GetListAsync(string categoryName)
            => await Task.FromResult(_dbContext.Decks
                .Where(x => x.Category.Name == categoryName)
                .Select(x => x.ToDto())
                .ToList()
            );
    }
}
