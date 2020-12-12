using System;
using System.Collections.Generic;

namespace Flashcards.Core
{
    public interface IDependencyResolver
    {
        T ResolveOrDefault<T>() where T : class;

        IEnumerable<object> ResolveMany(Type type);
    }
}
