using System;
using System.ComponentModel;
using System.Linq;

namespace Flashcards.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum e)
        {
            DescriptionAttribute attribute = e.GetType()
                .GetField(e.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;

            return attribute == null ? e.ToString() : attribute.Description;
        }
    }
}
