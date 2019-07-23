using System;
using System.Collections.Generic;
using System.Linq;
using Flashcards.Core.Exceptions;
using Flashcards.Domain.Dto;
using Flashcards.Domain.Entities;
using Flashcards.Domain.Enums;
using Flashcards.Domain.Extensions;
using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.DataAccess;
using Flashcards.Infrastructure.Extensions;
using Flashcards.Infrastructure.Managers.Abstract;

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

        public List<UserDto> GetAll()
            => _dbContext.Users.Select(x => x.ToDto()).ToList();

        public UserDto GetByEmail(string email)
            => _dbContext.Users
                .SingleAndEnsureExists(x => x.Email == email, ErrorCode.UserWithGivenEmailDoesNotExist)
                .ToDto();

        public void Update(Guid id, string email)
        {
            if (_dbContext.Users.ExistsSingleExceptFor(x => x.Email == email, id))
            {
                throw new FlashcardsException(ErrorCode.UserWithGivenEmailAlreadyExist);
            }
            var user = _dbContext.Users.SingleAndEnsureExists(x => x.Email == email, ErrorCode.UserWithGivenEmailDoesNotExist);
            user.SetEmail(email);

            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public void Login(string email, string password)
        {
            var user = _dbContext.Users.SingleAndEnsureExists(x => x.Email == email, ErrorCode.UserWithGivenEmailDoesNotExist);
            var hash = _encryptionManager.GetHash(password, user.Salt);

            if (user.Password != hash)
            {
                throw new FlashcardsException(ErrorCode.InvalidCredentials, "Invalid email or password");
            }
        }

        public void Register(Guid id, string email, Role role, string password)
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

            _dbContext.Users.Add(new User(id, email, role, hash, salt));
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = _dbContext.Users.FindAndEnsureExists(id, ErrorCode.UserDoesNotExist);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
