using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Users;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Commands.Handlers.Users
{
    internal class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommandModel>
    {
        private readonly IUsersCommandService _usersCommandService;

        public RegisterUserCommandHandler(IUsersCommandService usersCommandService)
        {
            _usersCommandService = usersCommandService;
        }

        public async Task HandleAsync(RegisterUserCommandModel command)
        {
            await _usersCommandService.RegisterAsync(command.Id, command.Email, command.Role, command.Password);
        }
    }
}
