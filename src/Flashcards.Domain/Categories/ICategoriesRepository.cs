using System;
using System.Collections.Generic;

namespace Flashcards.Domain.Categories
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
