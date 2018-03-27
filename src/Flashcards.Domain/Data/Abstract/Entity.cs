using System;

namespace Flashcards.Domain.Data.Abstract
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
    }
}
