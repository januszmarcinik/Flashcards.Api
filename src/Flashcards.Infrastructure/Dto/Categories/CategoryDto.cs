using Flashcards.Domain.Enums;
using System;

namespace Flashcards.Infrastructure.Dto.Categories
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Topic Topic { get; set; }
        public string TopicName { get; set; }
    }
}
