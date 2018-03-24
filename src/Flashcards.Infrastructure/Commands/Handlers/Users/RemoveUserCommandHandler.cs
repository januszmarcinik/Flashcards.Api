using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Users;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Commands.Handlers.Users
{
    internal class RemoveUserCommandHandler : ICommandHandler<RemoveUserCommandModel>
    {
        private readonly IUsersCommandService _usersCommandService;

        public RemoveUserCommandHandler(IUsersCommandService usersCommandService)
        {
            _usersCommandService = usersCommandService;
        }

        public async Task HandleAsync(RemoveUserCommandModel command)
        {
            await _usersCommandService.RemoveAsync(command.Id);
        }
    }
}
