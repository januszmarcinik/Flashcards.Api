using System;
using System.Collections.Generic;

namespace Flashcards.Domain.Users
{
    public interface IUsersRepository
    {
        List<UserDto> GetAll();
        UserDto GetByEmail(string email);
        User GetById(Guid id);
        IEnumerable<User> GetByIds(IEnumerable<Guid> ids);

        void Update(Guid id, string email);
        void Login(string email, string password);
        void Register(Guid guid, string email, Role role, string password);
        void Delete(Guid id);
    }
}
