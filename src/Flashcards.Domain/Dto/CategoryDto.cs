using System;
using Flashcards.Domain.Enums;

namespace Flashcards.Domain.Dto
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
