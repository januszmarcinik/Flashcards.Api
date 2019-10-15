using System;
using System.Collections.Generic;
using System.Linq;
using Flashcards.Core;
using Flashcards.Domain.Decks;

namespace Flashcards.Domain.Sessions
{
    internal class ApplySessionCardCommandHandler : CommandHandlerBase<ApplySessionCardCommand>
    {
        private readonly ICacheService _cache;
        private readonly IDecksRepository _decksRepository;
        private readonly ISessionsRepository _sessionsRepository;

        public ApplySessionCardCommandHandler(
            ICacheService cache, 
            IDecksRepository decksRepository, 
            ISessionsRepository sessionsRepository)
        {
            _cache = cache;
            _decksRepository = decksRepository;
            _sessionsRepository = sessionsRepository;
        }

        public override Result Handle(ApplySessionCardCommand command)
        {
            var sessionState = _cache.Get<SessionStateDto>(CacheKeys.GetSessionStateKey(command.UserId, command.Deck));
            var cards = _cache.Get<List<SessionCardDto>>(CacheKeys.GetSessionCardsKey(sessionState.Id));

            var card = cards.First(x => x.CardId == command.CardId);
            cards.Remove(card);

            if (command.IsOk)
            {
                sessionState.IncrementCounter();
            }
            else
            {
                cards.Add(card);
            }

            return cards.Count > 0 
                ? Next(command.UserId, command.Deck, sessionState, cards) 
                : Finish(command.UserId, command.Deck, sessionState);
        }

        private Result Next(Guid userId, string deckName, SessionStateDto sessionState, List<SessionCardDto> cards)
        {
            sessionState.SetCard(cards.First());
            _cache.Set(CacheKeys.GetSessionStateKey(userId, deckName), sessionState, TimeSpan.FromHours(1));
            _cache.Set(CacheKeys.GetSessionCardsKey(sessionState.Id), cards, TimeSpan.FromHours(1));

            return Ok();
        }

        private Result Finish(Guid userId, string deckName, SessionStateDto sessionState)
        {
            sessionState.Finish();
            _cache.Set(CacheKeys.GetSessionStateKey(userId, deckName), sessionState, TimeSpan.FromSeconds(1));
            _cache.Remove(CacheKeys.GetSessionCardsKey(sessionState.Id));

            var deck = _decksRepository.GetByName(deckName);
            var result = ((decimal)sessionState.TotalCount / (decimal)sessionState.TotalAttempts) * 100;
            var session = new Session(deck.Id, userId, DateTime.Now, result);

            _sessionsRepository.Add(session);

            return Ok();
        }
    }
}
