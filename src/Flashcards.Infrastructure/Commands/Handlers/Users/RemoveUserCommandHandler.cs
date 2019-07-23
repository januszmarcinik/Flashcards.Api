using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Users;
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

        public void Handle(RemoveUserCommandModel command)
        {
            _usersRepository.Delete(command.Id);
        }
    }
}
