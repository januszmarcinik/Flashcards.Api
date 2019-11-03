using System.Collections.Generic;
using System.Linq;
using Flashcards.Core;
using Flashcards.Domain.Decks;

namespace Flashcards.Domain.Cards
{
    internal class GetCardsByDeckQueryHandler : QueryHandlerBase<GetCardsByDeckQuery, IEnumerable<CardListItemDto>>
    {
        private readonly ICardsRepository _cardsRepository;
        private readonly IDecksRepository _decksRepository;

        public GetCardsByDeckQueryHandler(ICardsRepository cardsRepository, IDecksRepository decksRepository)
        {
            _cardsRepository = cardsRepository;
            _decksRepository = decksRepository;
        }

        public override Result<IEnumerable<CardListItemDto>> Handle(GetCardsByDeckQuery query)
        {
            var deck = _decksRepository.GetByName(query.Deck);
            if (deck == null)
            {
                return Fail("Deck with given name does not exist.");
            }

            var cards = _cardsRepository
                .GetByDeck(deck.Id)
                .Select(x => x.ToListItemDto())
                .ToList();

            return Ok(cards);
        }
    }
}
