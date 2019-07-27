using System;
using Flashcards.Core;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Extensions;

namespace Flashcards.Domain.Users
{
    internal class LoginUserCommandHandler : ICommandHandler<LoginUserCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ITokenService _tokenService;
        private readonly ICacheService _cache;

        public LoginUserCommandHandler(IUsersRepository usersRepository, ITokenService tokenService, ICacheService cache)
        {
            _usersRepository = usersRepository;
            _tokenService = tokenService;
            _cache = cache;
        }

        public Result Handle(LoginUserCommand command)
        {
            if (command.TokenId.IsEmpty())
            {
                command.TokenId = Guid.NewGuid();
            }

            _usersRepository.Login(command.Email, command.Password);
            var user = _usersRepository.GetByEmail(command.Email);

            var jwt = _tokenService.CreateToken(user.Id, user.Email, user.Role);
            _cache.SetJwt(command.TokenId, jwt);

            return Result.Ok();
        }
    }
}
