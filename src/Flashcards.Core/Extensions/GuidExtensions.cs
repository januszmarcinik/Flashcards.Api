using System;

namespace Flashcards.Core.Extensions
{
    public static class GuidExtensions
    {
        public static bool IsEmpty(this Guid guid)
        {
            return Guid.Empty == guid;
        }
    }
}
