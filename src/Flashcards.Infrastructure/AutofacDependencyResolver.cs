using System.Collections.Generic;
using Autofac;
using Flashcards.Core;

namespace Flashcards.Infrastructure
{
    public class AutofacDependencyResolver : IDependencyResolver
    {
        private readonly ILifetimeScope _lifetimeScope;

        public AutofacDependencyResolver(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public T ResolveOrDefault<T>() where T : class
            => _lifetimeScope.ResolveOptional<T>();

        public IEnumerable<T> ResolveMany<T>() where T : class => 
            _lifetimeScope.ResolveOptional<IEnumerable<T>>();
    }
}
