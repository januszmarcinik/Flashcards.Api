using Flashcards.Core;

namespace Flashcards.Domain.Users
{
    internal class RemoveUserCommandHandler : CommandHandlerBase<RemoveUserCommand>
    {
        private readonly IUsersRepository _usersRepository;

        public RemoveUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public override Result Handle(RemoveUserCommand command)
        {
            var user = _usersRepository.GetById(command.Id);
            if (user == null)
            {
                return Fail("User with given id does not exist.");
            }

            _usersRepository.Delete(user);
            return Ok();
        }
    }
}
