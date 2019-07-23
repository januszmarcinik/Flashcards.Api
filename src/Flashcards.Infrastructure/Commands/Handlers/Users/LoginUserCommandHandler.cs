using System;
using System.Threading.Tasks;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Users;
using Flashcards.Infrastructure.Extensions;
using Flashcards.Infrastructure.Managers.Abstract;
using Microsoft.Extensions.Caching.Memory;

namespace Flashcards.Infrastructure.Commands.Handlers.Users
{
    internal class LoginUserCommandHandler : ICommandHandler<LoginUserCommandModel>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtManager _jwtManager;
        private readonly IMemoryCache _cache;

        public LoginUserCommandHandler(IUsersRepository usersRepository, IJwtManager jwtManager, IMemoryCache cache)
        {
            _usersRepository = usersRepository;
            _jwtManager = jwtManager;
            _cache = cache;
        }

        public async Task HandleAsync(LoginUserCommandModel command)
        {
            if (command.TokenId.IsEmpty())
            {
                command.TokenId = Guid.NewGuid();
            }

            await _usersRepository.LoginAsync(command.Email, command.Password);
            var user = await _usersRepository.GetByEmailAsync(command.Email);

            var jwt = _jwtManager.CreateToken(user.Id, user.Email, user.Role);
            _cache.SetJwt(command.TokenId, jwt);
        }
    }
}
