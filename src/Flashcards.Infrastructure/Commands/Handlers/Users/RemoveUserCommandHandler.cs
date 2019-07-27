using Flashcards.Core;
using Flashcards.Infrastructure.Commands.Models.Users;
using Flashcards.Domain.Repositories;

namespace Flashcards.Infrastructure.Commands.Handlers.Users
{
    internal class RemoveUserCommandHandler : ICommandHandler<RemoveUserCommand>
    {
        private readonly IUsersRepository _usersRepository;

        public RemoveUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Result Handle(RemoveUserCommand command)
        {
            _usersRepository.Delete(command.Id);
            return Result.Ok();
        }
    }
}
