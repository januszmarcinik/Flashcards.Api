using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Users;
using System.Threading.Tasks;
using Flashcards.Domain.Repositories;

namespace Flashcards.Infrastructure.Commands.Handlers.Users
{
    internal class EditUserCommandHandler : ICommandHandler<EditUserCommandModel>
    {
        private readonly IUsersRepository _usersRepository;

        public EditUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task HandleAsync(EditUserCommandModel command)
        {
            await _usersRepository.EditAsync(command.Id, command.Email);
        }
    }
}
