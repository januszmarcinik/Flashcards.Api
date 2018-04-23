using Flashcards.Core.Exceptions;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Data.Abstract;
using Flashcards.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Flashcards.Domain.Entities
{
    public class Category : Entity
    {
        private readonly List<Deck> _decks = new List<Deck>();

        public string Name { get; protected set; }
        public Topic Topic { get; protected set; }
        public string Description { get; protected set; }
        public virtual IReadOnlyCollection<Deck> Decks => _decks;

        protected Category() { }

        public Category(Topic topic, string name, string description)
            : this(Guid.NewGuid(), topic, name, description) { }

        public Category(Guid id, Topic topic, string name, string description)
        {
            SetId(id);
            SetTopic(topic);
            SetName(name);
            SetDescription(description);
        }

        public void SetId(Guid id)
        {
            if (id.IsEmpty())
            {
                throw new FlashcardsException(ErrorCode.InvalidCategoryId);
            }

            Id = id;
        }

        public void SetTopic(Topic topic)
        {
            if (topic == 0)
            {
                throw new FlashcardsException(ErrorCode.InvalidCategoryTopic);
            }

            Topic = topic;
        }

        public void SetName(string name)
        {
            if (name.IsEmpty())
            {
                throw new FlashcardsException(ErrorCode.InvalidCategoryName);
            }

            Name = name;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void AddDeck(Deck deck)
        {
            _decks.Add(deck);
        }
    }
}
