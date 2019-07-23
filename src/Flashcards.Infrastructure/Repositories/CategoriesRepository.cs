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
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Infrastructure.Repositories
{
    internal class CategoriesRepository : ICategoriesRepository
    {
        private readonly EFContext _dbContext;

        public CategoriesRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CategoryDto>> GetByTopic(Topic topic)
            => await _dbContext.Categories
                .Where(x => x.Topic == topic)
                .Select(x => x.ToDto())
                .ToListAsync();

        public async Task<CategoryDto> GetByName(string name)
        {
            var category = _dbContext.Categories.SingleAndEnsureExists(x => x.Name == name, ErrorCode.CategoryDoesNotExist);
            return await Task.FromResult(category.ToDto());
        }

        public async Task AddAsync(string name, Topic topic, string description)
        {
            if (_dbContext.Categories.ExistsSingle(d => d.Name == name))
            {
                throw new FlashcardsException(ErrorCode.CategoryWithGivenNameAlreadyExist);
            }

            await _dbContext.Categories.AddAsync(new Category(topic, name, description));
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Guid id, string name, Topic topic, string description)
        {
            if (_dbContext.Categories.ExistsSingleExceptFor(d => d.Name == name, id))
            {
                throw new FlashcardsException(ErrorCode.CategoryWithGivenNameAlreadyExist);
            }

            var category = await _dbContext.Categories.FindAndEnsureExistsAsync(id, ErrorCode.CategoryDoesNotExist);
            category.SetName(name);
            category.SetTopic(topic);
            category.SetDescription(description);

            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var category = await _dbContext.Categories.FindAndEnsureExistsAsync(id, ErrorCode.CategoryDoesNotExist);
            if (category.Decks.Any())
            {
                throw new FlashcardsException(ErrorCode.CategoryCannotBeDeletedBecouseHasRelatedDecks);
            }

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
