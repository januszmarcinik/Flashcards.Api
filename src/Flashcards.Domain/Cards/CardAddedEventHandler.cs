using System;
using Flashcards.Core;
using Flashcards.Domain.Decks;
using Microsoft.Extensions.Logging;

namespace Flashcards.Domain.Cards
{
    public class CardAddedEventHandler : IEventHandler<CardAddedEvent>
    {
        private readonly ISqlCardsRepository _sqlCardsRepository;
        private readonly IDecksRepository _decksRepository;
        private readonly INoSqlCardsRepository _noSqlCardsRepository;
        private readonly ILogger<CardAddedEventHandler> _logger;

        public CardAddedEventHandler(
            ISqlCardsRepository sqlCardsRepository, 
            IDecksRepository decksRepository,
            INoSqlCardsRepository noSqlCardsRepository,
            ILogger<CardAddedEventHandler> logger)
        {
            _sqlCardsRepository = sqlCardsRepository;
            _decksRepository = decksRepository;
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

            var deck = _decksRepository.GetById(card.DeckId);
            if (deck == null)
            {
                _logger.LogError("Deck with Id {DeckId} does not exist", card.DeckId);
                return;
            }

            var previousCardId = GetPreviousAndUpdateLast(card);

            var dto = card.ToDto(deck.Name, previousCardId, Guid.Empty);
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