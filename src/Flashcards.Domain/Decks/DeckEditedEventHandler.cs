using System.Linq;
using Flashcards.Core;
using Flashcards.Domain.Cards;
using Microsoft.Extensions.Logging;

namespace Flashcards.Domain.Decks
{
    public class DeckEditedEventHandler : IEventHandler<DeckEditedEvent>
    {
        private readonly ISqlDecksRepository _sqlDecksRepository;
        private readonly INoSqlDecksRepository _noSqlDecksRepository;
        private readonly INoSqlCardsRepository _noSqlCardsRepository;
        private readonly ILogger<DeckEditedEventHandler> _logger;

        public DeckEditedEventHandler(
            ISqlDecksRepository sqlDecksRepository,
            INoSqlDecksRepository noSqlDecksRepository,
            INoSqlCardsRepository noSqlCardsRepository,
            ILogger<DeckEditedEventHandler> logger)
        {
            _sqlDecksRepository = sqlDecksRepository;
            _noSqlDecksRepository = noSqlDecksRepository;
            _noSqlCardsRepository = noSqlCardsRepository;
            _logger = logger;
        }
        
        public void Handle(DeckEditedEvent @event)
        {
            var deck = _sqlDecksRepository.GetById(@event.DeckId);
            if (deck == null)
            {
                _logger.LogError("Deck with Id {DeckId} does not exist", @event.DeckId);
                return;
            }

            var dto = _noSqlDecksRepository.GetById(deck.Id);
            var cards = _noSqlCardsRepository.GetByDeckName(dto.Name).ToList();
            foreach (var card in cards)
            {
                if (card.DeckName == deck.Name)
                {
                    break; // Name has not been changed.
                }
                
                var update = new CardDto(card.Id, card.DeckId, deck.Name, card.Question, card.Answer, card.Confirmed, card.PreviousCardId, card.NextCardId);
                _noSqlCardsRepository.Update(update);
            }

            dto = deck.ToDto(cards.Select(x => x.ToListItemDto()));
            _noSqlDecksRepository.Update(dto);
        }
    }
}