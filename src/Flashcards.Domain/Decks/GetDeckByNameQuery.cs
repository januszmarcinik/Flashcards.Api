using Flashcards.Core;

namespace Flashcards.Domain.Decks
{
    public class GetDeckByNameQuery : IQuery<DeckDto>
    {
        public string Name { get; }

        public GetDeckByNameQuery(string name)
        {
            Name = name;
        }
    }
}
