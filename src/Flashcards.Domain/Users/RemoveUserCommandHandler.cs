using Flashcards.Core;
using Flashcards.Domain.Repositories;

namespace Flashcards.Domain.Users
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
