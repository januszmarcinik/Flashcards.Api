using Flashcards.Core;
using Flashcards.Domain.Repositories;

namespace Flashcards.Domain.Users
{
    internal class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IUsersRepository _usersRepository;

        public RegisterUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Result Handle(RegisterUserCommand command)
        {
            _usersRepository.Register(command.Id, command.Email, command.Role, command.Password);
            return Result.Ok();
        }
    }
}
