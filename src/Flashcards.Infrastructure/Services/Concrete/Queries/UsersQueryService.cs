using AutoMapper;
using Flashcards.Domain.Repositories.Abstract;
using Flashcards.Infrastructure.Dto.Users;
using Flashcards.Infrastructure.Services.Abstract.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Concrete.Queries
{
    internal class UsersQueryService : IUsersQueryService
    {
        private IMapper _mapper;
        private IUsersRepository _usersRepository;

        public UsersQueryService(IMapper mapper, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<List<UserDto>> GetListAsync()
            => _mapper.Map<List<UserDto>>(await _usersRepository.GetAsync());

        public async Task<UserDto> GetByIdAsync(Guid id)
            => _mapper.Map<UserDto>(await _usersRepository.GetAndEnsureExistAsync(id));

        public async Task<UserDto> GetByEmailAsync(string email)
            => _mapper.Map<UserDto>(await _usersRepository.GetAsync(email));
    }
}
