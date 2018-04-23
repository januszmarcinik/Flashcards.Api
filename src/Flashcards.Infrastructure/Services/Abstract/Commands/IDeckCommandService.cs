using System;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Abstract.Commands
{
    public interface IDeckCommandService
    {
        Task CreateAsync(string categoryName, string deckName, string description);
        Task RemoveAsync(Guid id);
        Task EditAsync(Guid deckId, string deckName, string description);
    }
}
