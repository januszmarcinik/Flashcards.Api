using System;
using System.Linq;
using Flashcards.Core;
using Flashcards.Domain.Cards;
using Flashcards.Domain.Users;

namespace Flashcards.Domain.Sessions
{
    internal class GetSessionQueryHandler : IQueryHandler<GetSessionQuery, SessionStateDto>
    {
        private readonly ICacheService _cache;
        private readonly ICardsRepository _cardsRepository;

        public GetSessionQueryHandler(ICacheService cache, ICardsRepository cardsRepository)
        {
            _cache = cache;
            _cardsRepository = cardsRepository;
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

        private SessionStateDto Initialize(Guid userId, string deck)
        {
            var cards = _cardsRepository.GetByDeckName(deck);
            var sessionCards = cards.Select(x => new SessionCardDto(x.Id, x.Title, x.Answer, x.Question)).ToList();
            var sessionState = new SessionStateDto(userId, deck, sessionCards.Count);

            sessionState.SetCard(sessionCards.First());
            _cache.Set(CacheKeys.GetSessionStateKey(userId, deck), sessionState, TimeSpan.FromHours(1));
            _cache.Set(CacheKeys.GetSessionCardsKey(sessionState.Id), sessionCards, TimeSpan.FromHours(1));

            return sessionState;
        }
    }
}
