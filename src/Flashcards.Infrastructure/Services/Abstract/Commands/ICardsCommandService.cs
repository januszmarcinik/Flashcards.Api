using System;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Abstract.Commands
{
    public interface ICardsCommandService
    {
        Task AddAsync(string deckName, string title, string question, string answer);
        Task EditAsync(Guid id, string title, string question, string answer);
        Task RemoveAsync(Guid id);
    }
}
