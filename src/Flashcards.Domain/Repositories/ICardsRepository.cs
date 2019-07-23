using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flashcards.Domain.Dto;

namespace Flashcards.Domain.Repositories
{
    public interface ICardsRepository
    {
        Task<CardDto> GetAsync(Guid id);
        Task<List<CardDto>> GetListAsync(string deckName);

        Task AddAsync(string deckName, string title, string question, string answer);
        Task EditAsync(Guid cardId, string title, string question, string answer);
        Task RemoveAsync(Guid id);
        Task ConfirmAsync(Guid id);
    }
}
