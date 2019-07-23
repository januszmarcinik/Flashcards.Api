using Flashcards.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Domain.Extensions
{
    public static class DbSetExtensions
    {
        public static async Task<T> FindAndEnsureExistsAsync<T>(this DbSet<T> dbSet, Guid id, ErrorCode errorCode) where T : class, IEntity
        {
            var entity = await dbSet.FindAsync(id);
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
