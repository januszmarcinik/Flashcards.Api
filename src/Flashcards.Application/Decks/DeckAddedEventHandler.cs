using System.Linq;
using Flashcards.Core;
using Microsoft.Extensions.Logging;

namespace Flashcards.Application.Decks
{
    public class DeckAddedEventHandler : IEventHandler<DeckAddedEvent>
    {
        private readonly ISqlDecksRepository _decksRepository;
        private readonly INoSqlDecksRepository _noSqlDecksRepository;
        private readonly ILogger<DeckAddedEventHandler> _logger;

        public DeckAddedEventHandler(
            ISqlDecksRepository decksRepository,
            INoSqlDecksRepository noSqlDecksRepository,
            ILogger<DeckAddedEventHandler> logger)
        {
            _decksRepository = decksRepository;
            _noSqlDecksRepository = noSqlDecksRepository;
            _logger = logger;
        }
        
        public void Handle(DeckAddedEvent @event)
        {
            var deck = _decksRepository.GetById(@event.DeckId);
            if (deck == null)
            {
                _logger.LogError("Deck with Id {DeckId} does not exist", @event.DeckId);
                return;
            }

            var dto = deck.ToDto(Enumerable.Empty<DeckDto.Card>());
            _noSqlDecksRepository.Add(dto);
        }
    }
}