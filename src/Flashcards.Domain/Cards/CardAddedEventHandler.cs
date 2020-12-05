using System;
using Flashcards.Core;
using Microsoft.Extensions.Logging;

namespace Flashcards.Domain.Cards
{
    public class CardAddedEventHandler : IEventHandler<CardAddedEvent>
    {
        private readonly ISqlCardsRepository _sqlCardsRepository;
        private readonly INoSqlCardsRepository _noSqlCardsRepository;
        private readonly ILogger<CardAddedEventHandler> _logger;

        public CardAddedEventHandler(
            ISqlCardsRepository sqlCardsRepository, 
            INoSqlCardsRepository noSqlCardsRepository,
            ILogger<CardAddedEventHandler> logger)
        {
            _sqlCardsRepository = sqlCardsRepository;
            _noSqlCardsRepository = noSqlCardsRepository;
            _logger = logger;
        }
        
        public void Handle(CardAddedEvent @event)
        {
            var card = _sqlCardsRepository.GetById(@event.CardId);
            if (card == null)
            {
                _logger.LogError("Card with Id {CardId} does not exist", @event.CardId);
                return;
            }

            var previousCardId = GetPreviousAndUpdateLast(card);

            var dto = card.ToDto(previousCardId, Guid.Empty);
            _noSqlCardsRepository.Add(dto);
        }

        private Guid GetPreviousAndUpdateLast(Card card)
        {
            var last = _noSqlCardsRepository.GetLastByDeck(card.DeckId);
            if (last == null)
            {
                return Guid.Empty;
            }

            last = last.Recreate(last.PreviousCardId, card.Id);
            _noSqlCardsRepository.Update(last);

            return last.Id;
        }
    }
}