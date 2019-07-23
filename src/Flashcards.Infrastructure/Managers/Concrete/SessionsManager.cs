using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Domain.Dto;
using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.Managers.Abstract;
using Microsoft.Extensions.Caching.Memory;

namespace Flashcards.Infrastructure.Managers.Concrete
{
    internal class SessionsManager : ISessionsManager
    {
        private readonly IMemoryCache _cache;
        private readonly ICardsRepository _cardsRepository;

        public SessionsManager(IMemoryCache cache, ICardsRepository cardsRepository)
        {
            _cache = cache;
            _cardsRepository = cardsRepository;
        }

        public async Task<SessionStateDto> GetSessionAsync(Guid userId, string deck)
        {
            var session = _cache.Get<SessionStateDto>(GetSessionStateKey(userId, deck));
            if (session == null)
            {
                session = await InitializeAsync(userId, deck);
            }

            return session;
        }

        public async Task ApplySessionCardAsync(Guid userId, string deck, Guid cardId, SessionCardStatus status)
        {
            var session = _cache.Get<SessionStateDto>(GetSessionStateKey(userId, deck));
            var cards = _cache.Get<List<SessionCardDto>>(GetSessionCardsKey(session.Id));

            var card = cards.First(x => x.CardId == cardId);
            cards.Remove(card);

            if (status == SessionCardStatus.DoNotYet)
            {
                if (cards.Count > 5)
                {
                    cards.Insert(5, card);
                }
                else
                {
                    cards.Add(card);
                }
            }
            else if (status == SessionCardStatus.NotSure)
            {
                cards.Add(card);
            }
            else
            {
                session.IncrementCounter();
            }

            if (cards.Count > 0)
            {
                session.SetCard(cards.First());
                _cache.Set(GetSessionStateKey(userId, deck), session, TimeSpan.FromHours(1));
                _cache.Set(GetSessionCardsKey(session.Id), cards, TimeSpan.FromHours(1));
            }
            else
            {
                session.Finish();
                _cache.Set(GetSessionStateKey(userId, deck), session, TimeSpan.FromSeconds(1));
                _cache.Remove(GetSessionCardsKey(session.Id));
            }

            await Task.CompletedTask;
        }

        private async Task<SessionStateDto> InitializeAsync(Guid userId, string deck)
        {
            var cards = await _cardsRepository.GetListAsync(deck);
            var sessionCards = cards.Select(x => new SessionCardDto(x.Id, x.Title, x.Answer, x.Question)).ToList();
            var sessionState = new SessionStateDto(userId, deck, sessionCards.Count);

            sessionState.SetCard(sessionCards.First());
            _cache.Set(GetSessionStateKey(userId, deck), sessionState, TimeSpan.FromHours(1));
            _cache.Set(GetSessionCardsKey(sessionState.Id), sessionCards, TimeSpan.FromHours(1));

            return sessionState;
        }

        private static string GetSessionStateKey(Guid userId, string deck)
            => $"session-state-{userId}-{deck}";

        private static string GetSessionCardsKey(Guid sessionId)
            => $"session-cards-{sessionId}";
    }
}
