using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Users;
using System.Threading.Tasks;
using Flashcards.Domain.Repositories;

namespace Flashcards.Infrastructure.Commands.Handlers.Users
{
    internal class RemoveUserCommandHandler : ICommandHandler<RemoveUserCommandModel>
    {
        private readonly IUsersRepository _usersRepository;

        public RemoveUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task HandleAsync(RemoveUserCommandModel command)
        {
            await _usersRepository.RemoveAsync(command.Id);
        }
    }
}
