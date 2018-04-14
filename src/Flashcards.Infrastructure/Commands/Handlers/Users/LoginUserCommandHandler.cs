using System;
using System.Threading.Tasks;
using Flashcards.Core.Extensions;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Users;
using Flashcards.Infrastructure.Extensions;
using Flashcards.Infrastructure.Managers.Abstract;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using Flashcards.Infrastructure.Services.Abstract.Queries;
using Microsoft.Extensions.Caching.Memory;

namespace Flashcards.Infrastructure.Commands.Handlers.Users
{
    internal class LoginUserCommandHandler : ICommandHandler<LoginUserCommandModel>
    {
        private readonly IUsersCommandService _usersCommandService;
        private readonly IUsersQueryService _usersQueryService;
        private readonly IJwtManager _jwtManager;
        private readonly IMemoryCache _cache;

        public LoginUserCommandHandler(IUsersCommandService usersCommandService, IUsersQueryService usersQueryService, IJwtManager jwtManager, IMemoryCache cache)
        {
            _usersCommandService = usersCommandService;
            _usersQueryService = usersQueryService;
            _jwtManager = jwtManager;
            _cache = cache;
        }

        public async Task HandleAsync(LoginUserCommandModel command)
        {
            if (command.TokenId.IsEmpty())
            {
                command.TokenId = Guid.NewGuid();
            }

            await _usersCommandService.LoginAsync(command.Email, command.Password);
            var user = await _usersQueryService.GetByEmailAsync(command.Email);

            var jwt = _jwtManager.CreateToken(user.Id, user.Email, user.Role);
            _cache.SetJwt(command.TokenId, jwt);
        }
    }
}
