using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flashcards.Domain.Dto;

namespace Flashcards.Infrastructure.Services.Abstract.Queries
{
    public interface IUsersQueryService
    {
        Task<List<UserDto>> GetListAsync();
        Task<UserDto> GetByIdAsync(Guid id);
        Task<UserDto> GetByEmailAsync(string email);
    }
}
