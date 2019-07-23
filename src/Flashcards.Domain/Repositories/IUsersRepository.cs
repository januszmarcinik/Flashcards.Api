using System;
using System.Collections.Generic;
using Flashcards.Domain.Dto;
using Flashcards.Domain.Enums;

namespace Flashcards.Domain.Repositories
{
    public interface IUsersRepository
    {
        List<UserDto> GetAll();
        UserDto GetByEmail(string email);

        void Update(Guid id, string email);
        void Login(string email, string password);
        void Register(Guid guid, string email, Role role, string password);
        void Delete(Guid id);
    }
}
