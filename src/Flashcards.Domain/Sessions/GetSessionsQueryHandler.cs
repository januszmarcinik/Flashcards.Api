using System.Collections.Generic;
using System.Linq;
using Flashcards.Core;
using Flashcards.Domain.Decks;

namespace Flashcards.Domain.Sessions
{
    internal class GetSessionsQueryHandler : QueryHandlerBase<GetSessionsQuery, IEnumerable<SessionDto>>
    {
        private readonly ISessionsRepository _sessionsRepository;
        private readonly ISqlDecksRepository _decksRepository;

        public GetSessionsQueryHandler(ISessionsRepository sessionsRepository, ISqlDecksRepository decksRepository)
        {
            _sessionsRepository = sessionsRepository;
            _decksRepository = decksRepository;
        }

        public override Result<IEnumerable<SessionDto>> Handle(GetSessionsQuery query)
        {
            var deck = _decksRepository.GetByName(query.DeckName);
            if (deck == null)
            {
                return Fail("Deck with given name does not exist.");
            }

            var sessions = _sessionsRepository
                .GetBy(deck.Id, query.UserId)
                .Select(x => x.ToDto())
                .ToList();

            return Ok(sessions);
        }
    }
}
