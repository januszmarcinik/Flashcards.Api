using System.ComponentModel;

namespace Flashcards.Domain.Enums
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
