using Flashcards.Core;

namespace Flashcards.Domain.Users
{
    internal class RegisterUserCommandHandler : CommandHandlerBase<RegisterUserCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly EncryptionService _encryptionService;

        public RegisterUserCommandHandler(IUsersRepository usersRepository, EncryptionService encryptionService)
        {
            _usersRepository = usersRepository;
            _encryptionService = encryptionService;
        }

        public override Result Handle(RegisterUserCommand command)
        {
            if (_usersRepository.GetByEmail(command.Email) != null)
            {
                return Fail("User with given email already exists.");
            }

            var salt = _encryptionService.GetSalt(command.Password);
            var hash = _encryptionService.GetHash(command.Password, salt);

            _usersRepository.Add(new User(command.Email, Role.User, hash, salt));
            return Ok();
        }
    }
}
