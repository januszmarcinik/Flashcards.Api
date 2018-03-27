using Flashcards.Domain.Data.Abstract;
using System;
using System.Linq;

namespace Flashcards.Domain.Extensions
{
    public static class IQueryableExtensions
    {
        public static bool ExistsSingle<T>(this IQueryable<T> query, Func<T, bool> property)
        {
            return query.SingleOrDefault(property) != null;
        }

        public static bool ExistsSingleExceptFor<T>(this IQueryable<T> query, Func<T, bool> property, Guid id)
            where T : Entity
        {
            return query
                .Where(property)
                .Where(x => x.Id != id)
                .SingleOrDefault() != null;
        }
    }
}
