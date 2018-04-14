using System;
using System.Collections.Generic;
using System.Linq;

namespace Flashcards.Core.Extensions
{
    public static class GuidExtensions
    {
        public static bool IsEmpty(this Guid guid)
        {
            return Guid.Empty == guid;
        }

        public static Guid PreviousOrDefault(this IEnumerable<Guid> list, Guid current)
        {
            return list.TakeWhile(x => !x.Equals(current)).LastOrDefault();
        }

        public static Guid NextOrDefault(this IEnumerable<Guid> list, Guid current)
        {
            return list.SkipWhile(x => !x.Equals(current)).Skip(1).FirstOrDefault();
        }
    }
}
