using System;
using System.Collections.Generic;
using System.Linq;
using Flashcards.Core;

namespace Flashcards.Domain.Sessions
{
    internal class ApplySessionCardCommandHandler : CommandHandlerBase<ApplySessionCardCommand>
    {
        private readonly ICacheService _cache;

        public ApplySessionCardCommandHandler(ICacheService cache)
        {
            _cache = cache;
        }

        public override Result Handle(ApplySessionCardCommand command)
        {
            var session = _cache.Get<SessionStateDto>(CacheKeys.GetSessionStateKey(command.UserId, command.Deck));
            var cards = _cache.Get<List<SessionCardDto>>(CacheKeys.GetSessionCardsKey(session.Id));

            var card = cards.First(x => x.CardId == command.CardId);
            cards.Remove(card);

            if (command.IsOk)
            {
                session.IncrementCounter();
            }
            else
            {
                cards.Add(card);
            }

            if (cards.Count > 0)
            {
                session.SetCard(cards.First());
                _cache.Set(CacheKeys.GetSessionStateKey(command.UserId, command.Deck), session, TimeSpan.FromHours(1));
                _cache.Set(CacheKeys.GetSessionCardsKey(session.Id), cards, TimeSpan.FromHours(1));
            }
            else
            {
                session.Finish();
                _cache.Set(CacheKeys.GetSessionStateKey(command.UserId, command.Deck), session, TimeSpan.FromSeconds(1));
                _cache.Remove(CacheKeys.GetSessionCardsKey(session.Id));
            }

            return Ok();
        }
    }
}
