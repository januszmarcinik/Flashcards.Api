using Flashcards.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Abstract.Commands
{
    public interface ICardsCommandService
    {
        Task AddAsync(string deckName, string title, string question, string answer);
        Task AddRangeAsync(string deckName, List<Card> cards);
        Task EditAsync(Guid cardId, string title, string question, string answer);
        Task RemoveAsync(Guid id);
        Task ConfirmAsync(Guid id);
    }
}
