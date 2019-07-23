using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Core.Exceptions;
using Flashcards.Domain.Dto;
using Flashcards.Domain.Entities;
using Flashcards.Domain.Enums;
using Flashcards.Domain.Extensions;
using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.DataAccess;
using Flashcards.Infrastructure.Extensions;
using Flashcards.Infrastructure.Managers.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Infrastructure.Repositories
{
    internal class UsersRepository : IUsersRepository
    {
        private readonly EFContext _dbContext;
        private readonly IEncryptionManager _encryptionManager;

        public UsersRepository(EFContext dbContext, IEncryptionManager encryptionManager)
        {
            _dbContext = dbContext;
            _encryptionManager = encryptionManager;
        }

        public async Task<List<UserDto>> GetListAsync()
            => await _dbContext.Users.Select(x => x.ToDto()).ToListAsync();

        public async Task<UserDto> GetByEmailAsync(string email)
            => await Task.FromResult(_dbContext.Users
                .SingleAndEnsureExists(x => x.Email == email, ErrorCode.UserWithGivenEmailDoesNotExist)
                .ToDto()
            );

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
