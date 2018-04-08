using Flashcards.Core.Exceptions;
using Flashcards.Domain.Data.Abstract;
using Flashcards.Domain.Entities;
using Flashcards.Domain.Enums;
using Flashcards.Domain.Extensions;
using Flashcards.Infrastructure.Managers.Abstract;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Concrete.Commands
{
    internal class UsersCommandService : IUsersCommandService
    {
        private readonly IDbContext _dbContext;
        private readonly IEncryptionManager _encryptionManager;

        public UsersCommandService(IDbContext dbContext, IEncryptionManager encryptionManager)
        {
            _dbContext = dbContext;
            _encryptionManager = encryptionManager;
        }

        public async Task EditAsync(Guid id, string email)
        {
            if (_dbContext.Users.ExistsSingleExceptFor(x => x.Email == email, id))
            {
                throw new FlashcardsException(ErrorCode.UserWithGivenEmailAlreadyExist);
            }
            var user = _dbContext.Users.SingleAndEnsureExists(x => x.Email == email, ErrorCode.UserWithGivenEmailDoesNotExist);
            user.SetEmail(email);

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = _dbContext.Users.SingleAndEnsureExists(x => x.Email == email, ErrorCode.UserWithGivenEmailDoesNotExist);
            var hash = _encryptionManager.GetHash(password, user.Salt);

            if (user.Password != hash)
            {
                throw new FlashcardsException(ErrorCode.InvalidCredentials, "Invalid email or password");
            }

            await Task.CompletedTask;
        }

        public async Task RegisterAsync(Guid id, string email, Role role, string password)
        {
            if (_dbContext.Users.ExistsSingle(x => x.Email == email))
            {
                throw new FlashcardsException(ErrorCode.UserWithGivenEmailAlreadyExist);
            }

            var salt = _encryptionManager.GetSalt(password);
            var hash = _encryptionManager.GetHash(password, salt);

            if (id == Guid.Empty)
            {
                id = Guid.NewGuid();
            }

            await _dbContext.Users.AddAsync(new User(id, email, role, hash, salt));
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await _dbContext.Users.FindAndEnsureExistsAsync(id, ErrorCode.UserDoesNotExist);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
