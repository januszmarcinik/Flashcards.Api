using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Core.Exceptions;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Dto;
using Flashcards.Domain.Entities;
using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.DataAccess;
using Flashcards.Infrastructure.Extensions;

namespace Flashcards.Infrastructure.Repositories
{
    internal class CardsRepository : ICardsRepository
    {
        private readonly EFContext _dbContext;

        public CardsRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CardDto> GetAsync(Guid id)
        {
            var current = await _dbContext.Cards.FindAndEnsureExistsAsync(id, ErrorCode.CardDoesNotExist);
            var ids = current.Deck.Cards
                .OrderBy(x => x.Title)
                .Select(x => x.Id)
                .ToList();

            var dto = current.ToDto(ids.NextOrDefault(current.Id), ids.PreviousOrDefault(current.Id));
            return dto;
        }

        public async Task<List<CardDto>> GetListAsync(string deckName)
        {
            var deck = _dbContext.Decks.SingleAndEnsureExists(x => x.Name == deckName, ErrorCode.DeckDoesNotExist);
            var cards = deck.Cards
                .OrderBy(x => x.Title)
                .Select(x => x.ToDto())
                .ToList();
            return await Task.FromResult(cards);
        }

        public async Task AddAsync(string deckName, string title, string question, string answer)
        {
            var deck = _dbContext.Decks.SingleAndEnsureExists(x => x.Name == deckName, ErrorCode.DeckDoesNotExist);
            deck.AddCard(new Card(title, question, answer));
            _dbContext.Decks.Update(deck);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Guid cardId, string title, string question, string answer)
        {
            var card = await _dbContext.Cards.FindAndEnsureExistsAsync(cardId, ErrorCode.CardDoesNotExist);

            card.SetTitle(title);
            card.SetQuestion(question);
            card.SetAnswer(answer);

            _dbContext.Cards.Update(card);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var card = await _dbContext.Cards.FindAndEnsureExistsAsync(id, ErrorCode.CardDoesNotExist);
            _dbContext.Cards.Remove(card);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ConfirmAsync(Guid id)
        {
            var card = await _dbContext.Cards.FindAndEnsureExistsAsync(id, ErrorCode.CardDoesNotExist);
            card.SetConfirmed(!card.Confirmed);
            _dbContext.Cards.Update(card);
            await _dbContext.SaveChangesAsync();
        }
    }
}
