using Flashcards.Application.Cards;
using Flashcards.Core;

namespace Flashcards.Application.Decks
{
    public class DeckRemovedEventHandler : IEventHandler<DeckRemovedEvent>
    {
        private readonly INoSqlDecksRepository _noSqlDecksRepository;
        private readonly INoSqlCardsRepository _noSqlCardsRepository;

        public DeckRemovedEventHandler(
            INoSqlDecksRepository noSqlDecksRepository,
            INoSqlCardsRepository noSqlCardsRepository)
        {
            _noSqlDecksRepository = noSqlDecksRepository;
            _noSqlCardsRepository = noSqlCardsRepository;
        }
        
        public void Handle(DeckRemovedEvent @event)
        {
            _noSqlDecksRepository.Remove(@event.DeckId);
            _noSqlCardsRepository.RemoveByDeck(@event.DeckId);
        }
    }
}