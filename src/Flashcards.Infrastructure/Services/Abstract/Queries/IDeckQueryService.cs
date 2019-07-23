using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flashcards.Domain.Dto;

namespace Flashcards.Infrastructure.Services.Abstract.Queries
{
    public interface IDeckQueryService
    {
        Task<DeckDto> GetAsync(Guid id);
        Task<DeckDto> GetAsync(string name);
        Task<List<DeckDto>> GetListAsync();
        Task<List<DeckDto>> GetListAsync(string categoryName);
    }
}