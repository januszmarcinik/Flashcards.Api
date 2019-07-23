using Flashcards.Core.Exceptions;
using Flashcards.Domain.Enums;
using Flashcards.Infrastructure.Services.Abstract.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Domain.Dto;
using Flashcards.Infrastructure.DataAccess;
using Flashcards.Infrastructure.Extensions;

namespace Flashcards.Infrastructure.Services.Concrete.Queries
{
    internal class CategoriesQueryService : ICategoriesQueryService
    {
        private readonly EFContext _dbContext;

        public CategoriesQueryService(EFContext dbContext)
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
    }
}
