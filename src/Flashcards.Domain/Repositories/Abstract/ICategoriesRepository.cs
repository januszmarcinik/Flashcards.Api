using Flashcards.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Domain.Repositories.Abstract
{
    public interface ICategoriesRepository
    {
        Task<List<Category>> GetAsync();
        Task<IQueryable<Category>> QueryAsync();
        Task<Category> GetAsync(Guid id);
        Task<Category> GetAsync(string email);
        Task<Category> GetAndEnsureExistAsync(Guid id);

        Task CreateAsync(Category entity);
        Task UpdateAsync(Category entity);
        Task DeleteAsync(Category entity);
    }
}
