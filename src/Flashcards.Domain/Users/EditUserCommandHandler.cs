using Flashcards.Core;
using Flashcards.Domain.Repositories;

namespace Flashcards.Domain.Users
{
    internal class EditUserCommandHandler : ICommandHandler<EditUserCommand>
    {
        private readonly IUsersRepository _usersRepository;

        public EditUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Result Handle(EditUserCommand command)
        {
            _usersRepository.Update(command.Id, command.Email);
            return Result.Ok();
        }
    }
}
