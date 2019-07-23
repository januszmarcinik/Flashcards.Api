using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flashcards.Domain.Dto;
using Flashcards.Domain.Enums;

namespace Flashcards.Domain.Repositories
{
    public interface IUsersRepository
    {
        Task<List<UserDto>> GetListAsync();
        Task<UserDto> GetByEmailAsync(string email);

        Task EditAsync(Guid id, string email);
        Task LoginAsync(string email, string password);
        Task RegisterAsync(Guid guid, string email, Role role, string password);
        Task RemoveAsync(Guid id);
    }
}
