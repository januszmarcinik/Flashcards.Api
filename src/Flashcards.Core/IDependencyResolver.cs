using System.Collections.Generic;

namespace Flashcards.Core
{
    public interface IDependencyResolver
    {
        T ResolveOrDefault<T>() where T : class;

        IEnumerable<T> ResolveMany<T>() where T : class;
    }
}
