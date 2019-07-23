using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Users;
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

        public void Handle(EditUserCommandModel command)
        {
            _usersRepository.Update(command.Id, command.Email);
        }
    }
}
