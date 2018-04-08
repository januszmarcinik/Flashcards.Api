using AutoMapper;
using Flashcards.Core.Exceptions;
using Flashcards.Domain.Data.Abstract;
using Flashcards.Domain.Enums;
using Flashcards.Domain.Extensions;
using Flashcards.Infrastructure.Dto.Categories;
using Flashcards.Infrastructure.Services.Abstract.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Concrete.Queries
{
    internal class CategoriesQueryService : ICategoriesQueryService
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoriesQueryService(IDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<List<CategoryDto>> GetByTopic(Topic topic)
            => _mapper.Map<List<CategoryDto>>(await _dbContext.Categories.Where(x => x.Topic == topic).ToListAsync());

        public async Task<CategoryDto> GetByName(string name)
        {
            var category = _dbContext.Categories.SingleAndEnsureExists(x => x.Name == name, ErrorCode.CategoryDoesNotExist);
            return await Task.FromResult(_mapper.Map<CategoryDto>(category));
        }
    }
}
