using System;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Abstract.Commands
{
    public interface ICommentsCommandService
    {
        Task AddAsync(Guid cardId, Guid userId, string text);
    }
}
