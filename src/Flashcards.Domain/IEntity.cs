using System;

namespace Flashcards.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
