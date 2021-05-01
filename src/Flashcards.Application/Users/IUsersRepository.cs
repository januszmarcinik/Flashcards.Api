using System;
using System.Collections.Generic;

namespace Flashcards.Application.Users
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetAll();
        User GetByEmail(string email);
        User GetById(Guid id);
        IEnumerable<User> GetByIds(IEnumerable<Guid> ids);

        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
