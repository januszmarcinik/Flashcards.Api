using System.Collections.Generic;
using System.Linq;
using Flashcards.Core;

namespace Flashcards.Domain.Decks
{
    internal class GetAllDecksQueryHandler : QueryHandlerBase<GetAllDecksQuery, IEnumerable<DeckDto>>
    {
        private readonly IDecksRepository _decksRepository;

        public GetAllDecksQueryHandler(IDecksRepository decksRepository)
        {
            _decksRepository = decksRepository;
        }

        public override Result<IEnumerable<DeckDto>> Handle(GetAllDecksQuery query)
        {
            var result = _decksRepository
                .GetAll()
                .Select(x => x.ToDto())
                .ToList();

            return Ok(result);
        }
    }
}
