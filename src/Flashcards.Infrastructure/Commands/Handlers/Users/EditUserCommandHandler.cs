using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Users;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Commands.Handlers.Users
{
    internal class EditUserCommandHandler : ICommandHandler<EditUserCommandModel>
    {
        private readonly IUsersCommandService _usersCommandService;

        public EditUserCommandHandler(IUsersCommandService usersCommandService)
        {
            _usersCommandService = usersCommandService;
        }

        public async Task HandleAsync(EditUserCommandModel command)
        {
            await _usersCommandService.EditAsync(command.Id, command.Email);
        }
    }
}
