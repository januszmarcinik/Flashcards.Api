using Flashcards.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Domain.Repositories.Abstract
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAsync();
        Task<IQueryable<User>> QueryAsync();
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task<User> GetAndEnsureExistAsync(Guid id);

        Task CreateAsync(User entity);
        Task UpdateAsync(User entity);
        Task DeleteAsync(User entity);
    }
}
