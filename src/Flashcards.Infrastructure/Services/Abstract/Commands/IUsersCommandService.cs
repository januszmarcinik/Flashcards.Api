using Flashcards.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Abstract.Commands
{
    public interface IUsersCommandService
    {
        Task EditAsync(Guid id, string email);
        Task LoginAsync(string email, string password);
        Task RegisterAsync(Guid guid, string email, Role role, string password);
        Task RemoveAsync(Guid id);
    }
}
