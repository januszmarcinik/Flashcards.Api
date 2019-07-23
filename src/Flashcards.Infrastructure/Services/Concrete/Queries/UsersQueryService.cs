using Flashcards.Core.Exceptions;
using Flashcards.Infrastructure.Services.Abstract.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Domain.Dto;
using Flashcards.Infrastructure.DataAccess;
using Flashcards.Infrastructure.Extensions;

namespace Flashcards.Infrastructure.Services.Concrete.Queries
{
    internal class UsersQueryService : IUsersQueryService
    {
        private readonly EFContext _dbContext;

        public UsersQueryService(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserDto>> GetListAsync()
            => await _dbContext.Users.Select(x => x.ToDto()).ToListAsync();

        public async Task<UserDto> GetByIdAsync(Guid id)
            => (await _dbContext.Users.FindAndEnsureExistsAsync(id, ErrorCode.UserDoesNotExist)).ToDto();

        public async Task<UserDto> GetByEmailAsync(string email)
            => await Task.FromResult(_dbContext.Users.SingleAndEnsureExists(x => x.Email == email, ErrorCode.UserWithGivenEmailDoesNotExist).ToDto());
    }
}
