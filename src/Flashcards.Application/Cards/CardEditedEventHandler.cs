using System.Linq;
using Flashcards.Application.Decks;
using Flashcards.Core;
using Microsoft.Extensions.Logging;

namespace Flashcards.Application.Cards
{
    public class CardEditedEventHandler : IEventHandler<CardEditedEvent>
    {
        private readonly ISqlCardsRepository _sqlCardsRepository;
        private readonly INoSqlCardsRepository _noSqlCardsRepository;
        private readonly INoSqlDecksRepository _noSqlDecksRepository;
        private readonly ILogger<CardEditedEventHandler> _logger;

        public CardEditedEventHandler(
            ISqlCardsRepository sqlCardsRepository, 
            INoSqlCardsRepository noSqlCardsRepository,
            INoSqlDecksRepository noSqlDecksRepository,
            ILogger<CardEditedEventHandler> logger)
        {
            _sqlCardsRepository = sqlCardsRepository;
            _noSqlCardsRepository = noSqlCardsRepository;
            _noSqlDecksRepository = noSqlDecksRepository;
            _logger = logger;
        }
        
        public void Handle(CardEditedEvent @event)
        {
            var card = _sqlCardsRepository.GetById(@event.CardId);
            if (card == null)
            {
                _logger.LogError("Card with Id {CardId} does not exist", @event.CardId);
                return;
            }

            var dto = _noSqlCardsRepository.GetById(@event.CardId);

            dto = card.ToDto(dto.DeckName, dto.PreviousCardId, dto.NextCardId);
            _noSqlCardsRepository.Update(dto);
            
            UpdateDeck(dto);
        }
        
        private void UpdateDeck(CardDto card)
        {
            var dto = _noSqlDecksRepository.GetByName(card.DeckName);
            var cards = dto.Cards.ToList();
            var indexToReplace = cards.FindIndex(x => x.Id == card.Id);
            cards[indexToReplace] = card.ToListItemDto();
            
            _noSqlDecksRepository.UpdateCards(dto.Id, cards);
        }
    }
}