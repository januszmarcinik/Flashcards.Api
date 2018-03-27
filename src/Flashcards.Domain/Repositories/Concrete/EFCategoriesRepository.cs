using Flashcards.Core.Exceptions;
using Flashcards.Domain.Data.Abstract;
using Flashcards.Domain.Entities;
using Flashcards.Domain.Extensions;
using Flashcards.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Domain.Repositories.Concrete
{
    internal class EFCategoriesRepository : ICategoriesRepository
    {
        private readonly IDbContext _context;

        public EFCategoriesRepository(IDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetAsync(Guid id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> GetAsync(string name)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Name == name);
            if (category == null)
            {
                throw new FlashcardsException(ErrorCode.CategoryWithGivenNameDoesNotExist, name);
            }

            return category;
        }

        public async Task<Category> GetAndEnsureExistAsync(Guid id)
        {
            var entity = await GetAsync(id);
            if (entity == null)
            {
                throw new FlashcardsException(ErrorCode.CategoryDoesNotExist, id.ToString());
            }

            return entity;
        }

        public Task<IQueryable<Category>> QueryAsync()
        {
            return Task.FromResult(_context.Categories.AsNoTracking());
        }

        public async Task CreateAsync(Category entity)
        {
            if (_context.Categories.ExistsSingle(x => x.Name == entity.Name))
            {
                throw new FlashcardsException(ErrorCode.CategoryWithGivenNameAlreadyExist, entity.Name);
            }

            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category entity)
        {
            if (_context.Categories.ExistsSingleExceptFor(x => x.Name == entity.Name, entity.Id))
            {
                throw new FlashcardsException(ErrorCode.CategoryWithGivenNameAlreadyExist, entity.Name);
            }

            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category entity)
        {
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
