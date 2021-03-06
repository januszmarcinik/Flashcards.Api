﻿using System;
using System.Linq;
using Flashcards.Application.Cache;
using Flashcards.Application.Cards;
using Flashcards.Core;

namespace Flashcards.Application.Sessions
{
    internal class GetSessionQueryHandler : IQueryHandler<GetSessionQuery, SessionStateDto>
    {
        private readonly ICacheService _cache;
        private readonly INoSqlCardsRepository _noSqlCardsRepository;

        public GetSessionQueryHandler(ICacheService cache, INoSqlCardsRepository noSqlCardsRepository)
        {
            _cache = cache;
            _noSqlCardsRepository = noSqlCardsRepository;
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
            var cards = _noSqlCardsRepository.GetByDeckName(deckName);
            var sessionCards = cards.Select(x => new SessionCardDto(x.Id, x.Answer, x.Question)).ToList();
            var sessionState = new SessionStateDto(userId, deckName, sessionCards.Count);

            sessionState.SetCard(sessionCards.First());
            _cache.Set(CacheKeys.GetSessionStateKey(userId, deckName), sessionState, TimeSpan.FromHours(1));
            _cache.Set(CacheKeys.GetSessionCardsKey(sessionState.Id), sessionCards, TimeSpan.FromHours(1));

            return sessionState;
        }
    }
}
