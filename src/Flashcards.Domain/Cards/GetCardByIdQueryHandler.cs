using System.Linq;
using Flashcards.Core;
using Flashcards.Core.Extensions;

namespace Flashcards.Domain.Cards
{
    internal class GetCardByIdQueryHandler : QueryHandlerBase<GetCardByIdQuery, CardDto>
    {
        private readonly ICardsRepository _cardsRepository;

        public GetCardByIdQueryHandler(ICardsRepository cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }

        public override Result<CardDto> Handle(GetCardByIdQuery query)
        {
            var card = _cardsRepository.GetById(query.Id);
            if (card == null)
            {
                return Fail("Card with given ID does not exist.");
            }

            var ids = _cardsRepository
                .GetByDeck(card.DeckId)
                .Select(x => x.Id)
                .ToList();

            var result = card.ToDto(ids.NextOrDefault(card.Id), ids.PreviousOrDefault(card.Id));

            return Ok(result);
        }
    }
}
