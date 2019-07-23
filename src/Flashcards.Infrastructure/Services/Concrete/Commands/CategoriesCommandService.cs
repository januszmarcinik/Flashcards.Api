using Flashcards.Core.Exceptions;
using Flashcards.Domain.Entities;
using Flashcards.Domain.Enums;
using Flashcards.Domain.Extensions;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Domain.Data.Concrete;

namespace Flashcards.Infrastructure.Services.Concrete.Commands
{
    internal class CategoriesCommandService : ICategoriesCommandService
    {
        private readonly EFContext _dbContext;

        public CategoriesCommandService(EFContext dbContext)
        {
            _dbContext = dbContext;
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
