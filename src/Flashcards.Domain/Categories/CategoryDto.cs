using System;

namespace Flashcards.Domain.Categories
{
    public class CategoryDto
    {
        public CategoryDto(Guid id, string name, string description, Topic topic, string topicName)
        {
            Id = id;
            Name = name;
            Description = description;
            Topic = topic;
            TopicName = topicName;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public Topic Topic { get; }
        public string TopicName { get; }
    }
}
