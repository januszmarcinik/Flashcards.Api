using AutoMapper;
using Flashcards.Core.Exceptions;
using Flashcards.Domain.Data.Abstract;
using Flashcards.Domain.Extensions;
using Flashcards.Infrastructure.Dto.Users;
using Flashcards.Infrastructure.Services.Abstract.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Concrete.Queries
{
    internal class UsersQueryService : IUsersQueryService
    {
        private IMapper _mapper;
        private IDbContext _dbContext;

        public UsersQueryService(IMapper mapper, IDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<List<UserDto>> GetListAsync()
            => _mapper.Map<List<UserDto>>(await _dbContext.Users.ToListAsync());

        public async Task<UserDto> GetByIdAsync(Guid id)
            => _mapper.Map<UserDto>(await _dbContext.Users.FindAndEnsureExistsAsync(id, ErrorCode.UserDoesNotExist));

        public async Task<UserDto> GetByEmailAsync(string email)
            => await Task.FromResult(_mapper.Map<UserDto>(_dbContext.Users.SingleAndEnsureExists(x => x.Email == email, ErrorCode.UserWithGivenEmailDoesNotExist)));
    }
}
