using Flashcards.Core.Exceptions;
using Flashcards.Domain.Entities;
using Flashcards.Domain.Enums;
using Flashcards.Domain.Repositories.Abstract;
using Flashcards.Infrastructure.Managers.Abstract;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Concrete.Commands
{
    internal class UsersCommandService : IUsersCommandService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IEncryptionManager _encryptionManager;

        public UsersCommandService(IUsersRepository usersRepository, IEncryptionManager encryptionManager)
        {
            _usersRepository = usersRepository;
            _encryptionManager = encryptionManager;
        }

        public async Task EditAsync(Guid id, string email)
        {
            var user = await _usersRepository.GetAndEnsureExistAsync(id);
            user.SetEmail(email);
            await _usersRepository.UpdateAsync(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _usersRepository.GetAsync(email);
            var hash = _encryptionManager.GetHash(password, user.Salt);

            if (user.Password != hash)
            {
                throw new FlashcardsException(ErrorCode.InvalidCredentials);
            }
        }

        public async Task RegisterAsync(Guid id, string email, Role role, string password)
        {
            var salt = _encryptionManager.GetSalt(password);
            var hash = _encryptionManager.GetHash(password, salt);

            if (id == Guid.Empty)
            {
                id = Guid.NewGuid();
            }

            await _usersRepository.CreateAsync(new User(id, email, role, hash, salt));
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await _usersRepository.GetAndEnsureExistAsync(id);
            await _usersRepository.DeleteAsync(user);
        }
    }
}
