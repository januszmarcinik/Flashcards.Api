using System;
using System.Collections.Generic;
using Flashcards.Domain.Dto;
using Flashcards.Domain.Enums;

namespace Flashcards.Domain.Repositories
{
    public interface ICategoriesRepository
    {
        List<CategoryDto> GetByTopic(Topic topic);
        CategoryDto GetByName(string name);

        void Add(string name, Topic topic, string description);
        void Update(Guid id, string name, Topic topic, string description);
        void Delete(Guid id);
    }
}
