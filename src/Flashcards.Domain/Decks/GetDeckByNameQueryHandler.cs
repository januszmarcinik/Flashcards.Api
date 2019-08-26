using Flashcards.Core;

namespace Flashcards.Domain.Decks
{
    internal class GetDeckByNameQueryHandler : QueryHandlerBase<GetDeckByNameQuery, DeckDto>
    {
        private readonly IDecksRepository _decksRepository;

        public GetDeckByNameQueryHandler(IDecksRepository decksRepository)
        {
            _decksRepository = decksRepository;
        }

        public override Result<DeckDto> Handle(GetDeckByNameQuery query)
        {
            var result = _decksRepository.GetByName(query.Name);
            if (result == null)
            {
                return Fail("Deck with given name does not exist.");
            }

            return Ok(result.ToDto());
        }
    }
}
