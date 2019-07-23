using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flashcards.Domain.Dto;

namespace Flashcards.Domain.Repositories
{
    public interface IDecksRepository
    {
        Task<DeckDto> GetAsync(string name);
        Task<List<DeckDto>> GetListAsync(string categoryName);

        Task CreateAsync(string categoryName, string deckName, string description);
        Task RemoveAsync(Guid id);
        Task EditAsync(Guid deckId, string deckName, string description);
    }
}