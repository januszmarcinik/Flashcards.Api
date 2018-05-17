using System;

namespace Flashcards.WindowsUI.Extensions
{
    public static class GuidExtensions
    {
        public static bool IsEmpty(this Guid guid)
        {
            return Guid.Empty == guid;
        }
    }
}
