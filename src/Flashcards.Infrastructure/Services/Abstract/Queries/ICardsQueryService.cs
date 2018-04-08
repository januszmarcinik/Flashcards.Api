using Flashcards.Infrastructure.Dto.Cards;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Abstract.Queries
{
    public interface ICardsQueryService
    {
        Task<CardDto> GetAsync(Guid id);
        Task<List<CardDto>> GetListAsync(string deckName);
    }
}
