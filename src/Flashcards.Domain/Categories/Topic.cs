using System.ComponentModel;

namespace Flashcards.Domain.Categories
{
    public enum Topic
    {
        Default = 0,

        [Description("IT")]
        It = 1,

        [Description("English-Polish")]
        EnPl = 2
    }
}
