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

namespace Flashcards.Infrastructure.Repositories
{
    internal class CategoriesRepository : ICategoriesRepository
    {
        private readonly EFContext _dbContext;

        public CategoriesRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CategoryDto> GetByTopic(Topic topic)
            => _dbContext.Categories
                .Where(x => x.Topic == topic)
                .Select(x => x.ToDto())
                .ToList();

        public CategoryDto GetByName(string name)
        {
            var category = _dbContext.Categories.SingleAndEnsureExists(x => x.Name == name, ErrorCode.CategoryDoesNotExist);
            return category.ToDto();
        }

        public void Add(string name, Topic topic, string description)
        {
            if (_dbContext.Categories.ExistsSingle(d => d.Name == name))
            {
                throw new FlashcardsException(ErrorCode.CategoryWithGivenNameAlreadyExist);
            }

            _dbContext.Categories.Add(new Category(topic, name, description));
            _dbContext.SaveChanges();
        }

        public void Update(Guid id, string name, Topic topic, string description)
        {
            if (_dbContext.Categories.ExistsSingleExceptFor(d => d.Name == name, id))
            {
                throw new FlashcardsException(ErrorCode.CategoryWithGivenNameAlreadyExist);
            }

            var category = _dbContext.Categories.FindAndEnsureExists(id, ErrorCode.CategoryDoesNotExist);
            category.SetName(name);
            category.SetTopic(topic);
            category.SetDescription(description);

            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var category = _dbContext.Categories.FindAndEnsureExists(id, ErrorCode.CategoryDoesNotExist);
            if (category.Decks.Any())
            {
                throw new FlashcardsException(ErrorCode.CategoryCannotBeDeletedBecouseHasRelatedDecks);
            }

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }
    }
}
