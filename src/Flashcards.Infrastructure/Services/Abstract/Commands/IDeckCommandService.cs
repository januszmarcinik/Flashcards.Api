using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Abstract.Commands
{
    public interface IDeckCommandService
    {
        Task CreateAsync(string categoryName, string deckName);
    }
}
