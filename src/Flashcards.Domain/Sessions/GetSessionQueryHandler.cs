using System;
using System.Linq;
using Flashcards.Core;
using Flashcards.Domain.Cards;
using Flashcards.Domain.Decks;

namespace Flashcards.Domain.Sessions
{
    internal class GetSessionQueryHandler : IQueryHandler<GetSessionQuery, SessionStateDto>
    {
        private readonly ICacheService _cache;
        private readonly ICardsRepository _cardsRepository;
        private readonly IDecksRepository _decksRepository;

        public GetSessionQueryHandler(ICacheService cache, ICardsRepository cardsRepository, IDecksRepository decksRepository)
        {
            _cache = cache;
            _cardsRepository = cardsRepository;
            _decksRepository = decksRepository;
        }

        public Result<SessionStateDto> Handle(GetSessionQuery query)
        {
            var session = _cache.Get<SessionStateDto>(CacheKeys.GetSessionStateKey(query.UserId, query.Deck));
            if (session == null)
            {
                session = Initialize(query.UserId, query.Deck);
            }

            return Result.Ok(session);
        }

        private SessionStateDto Initialize(Guid userId, string deckName)
        {
            var deck = _decksRepository.GetByName(deckName);
            var cards = _cardsRepository.GetByDeck(deck.Id);
            var sessionCards = cards.Select(x => new SessionCardDto(x.Id, x.Answer, x.Question)).ToList();
            var sessionState = new SessionStateDto(userId, deckName, sessionCards.Count);

            sessionState.SetCard(sessionCards.First());
            _cache.Set(CacheKeys.GetSessionStateKey(userId, deckName), sessionState, TimeSpan.FromHours(1));
            _cache.Set(CacheKeys.GetSessionCardsKey(sessionState.Id), sessionCards, TimeSpan.FromHours(1));

            return sessionState;
        }
    }
}
