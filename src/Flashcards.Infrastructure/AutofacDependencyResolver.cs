using System;
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

        public IEnumerable<object> ResolveMany(Type type)
        {
            var enumerableType = typeof(IEnumerable<>).MakeGenericType(type);
            return (IEnumerable<object>)_lifetimeScope.ResolveOptional(enumerableType);
        }
    }
}
