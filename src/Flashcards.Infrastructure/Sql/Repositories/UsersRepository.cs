using System;
using System.Collections.Generic;
using System.Linq;
using Flashcards.Domain.Users;

namespace Flashcards.Infrastructure.Sql.Repositories
{
    internal class UsersRepository : IUsersRepository
    {
        private readonly EFContext _dbContext;

        public UsersRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetAll()
            => _dbContext.Users.ToList();

        public User GetByEmail(string email)
            => _dbContext.Users.SingleOrDefault(x => x.Email == email);

        public User GetById(Guid id)
            => _dbContext.Users.SingleOrDefault(x => x.Id == id);

        public IEnumerable<User> GetByIds(IEnumerable<Guid> ids)
            => _dbContext.Users
                .Where(x => ids.Contains(x.Id))
                .ToList();


        public void Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
