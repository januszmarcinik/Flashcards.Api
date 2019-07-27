using System;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Repositories;
using Flashcards.Domain.Services;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Users;
using Flashcards.Infrastructure.Extensions;
using Microsoft.Extensions.Caching.Memory;

namespace Flashcards.Infrastructure.Commands.Handlers.Users
{
    internal class LoginUserCommandHandler : ICommandHandler<LoginUserCommandModel>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ITokenService _tokenService;
        private readonly IMemoryCache _cache;

        public LoginUserCommandHandler(IUsersRepository usersRepository, ITokenService tokenService, IMemoryCache cache)
        {
            _usersRepository = usersRepository;
            _tokenService = tokenService;
            _cache = cache;
        }

        public void Handle(LoginUserCommandModel command)
        {
            if (command.TokenId.IsEmpty())
            {
                command.TokenId = Guid.NewGuid();
            }

            _usersRepository.Login(command.Email, command.Password);
            var user = _usersRepository.GetByEmail(command.Email);

            var jwt = _tokenService.CreateToken(user.Id, user.Email, user.Role);
            _cache.SetJwt(command.TokenId, jwt);
        }
    }
}
