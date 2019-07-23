using System;
using System.Linq;
using Flashcards.Core.Exceptions;
using Flashcards.Domain;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Infrastructure.Extensions
{
    public static class DbSetExtensions
    {
        public static T FindAndEnsureExists<T>(this DbSet<T> dbSet, Guid id, ErrorCode errorCode) where T : class, IEntity
        {
            var entity = dbSet.Find(id);
            if (entity == null)
            {
                throw new FlashcardsException(errorCode);
            }

            return entity;
        }

        public static T SingleAndEnsureExists<T>(this DbSet<T> dbSet, Func<T, bool> property, ErrorCode errorCode) where T : class, IEntity
        {
            var entity = dbSet.SingleOrDefault(property);
            if (entity == null)
            {
                throw new FlashcardsException(errorCode);
            }

            return entity;
        }
    }
}
