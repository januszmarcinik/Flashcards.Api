using Flashcards.Domain.Enums;
using Flashcards.Infrastructure.Dto.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Abstract.Queries
{
    public interface ICategoriesQueryService
    {
        Task<List<CategoryDto>> GetByTopic(Topic topic);
        Task<CategoryDto> GetByName(string name);
    }   
}
