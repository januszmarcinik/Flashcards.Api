using Flashcards.Infrastructure.Dto.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Abstract.Queries
{
    public interface IUsersQueryService
    {
        Task<List<UserDto>> GetListAsync();
        Task<UserDto> GetByIdAsync(Guid id);
        Task<UserDto> GetByEmailAsync(string email);
    }
}
