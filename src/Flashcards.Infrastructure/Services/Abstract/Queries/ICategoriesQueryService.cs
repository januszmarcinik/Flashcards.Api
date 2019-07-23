using Flashcards.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flashcards.Domain.Dto;

namespace Flashcards.Infrastructure.Services.Abstract.Queries
{
    public interface ICategoriesQueryService
    {
        Task<List<CategoryDto>> GetByTopic(Topic topic);
        Task<CategoryDto> GetByName(string name);
    }   
}
