using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flashcards.Domain.Dto;
using Flashcards.Domain.Enums;

namespace Flashcards.Domain.Repositories
{
    public interface ICategoriesRepository
    {
        Task<List<CategoryDto>> GetByTopic(Topic topic);
        Task<CategoryDto> GetByName(string name);

        Task AddAsync(string name, Topic topic, string description);
        Task EditAsync(Guid id, string name, Topic topic, string description);
        Task RemoveAsync(Guid id);
    }
}
