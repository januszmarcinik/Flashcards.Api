using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Users;
using System.Threading.Tasks;
using Flashcards.Domain.Repositories;

namespace Flashcards.Infrastructure.Commands.Handlers.Users
{
    internal class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommandModel>
    {
        private readonly IUsersRepository _usersRepository;

        public RegisterUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task HandleAsync(RegisterUserCommandModel command)
        {
            await _usersRepository.RegisterAsync(command.Id, command.Email, command.Role, command.Password);
        }
    }
}
