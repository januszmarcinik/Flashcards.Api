using Flashcards.Core.Exceptions;
using Flashcards.Domain.Entities;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flashcards.Infrastructure.DataAccess;
using Flashcards.Infrastructure.Extensions;
using Flashcards.Infrastructure.Managers.Abstract;

namespace Flashcards.Infrastructure.Services.Concrete.Commands
{
    internal class CardsCommandService : ICardsCommandService
    {
        private readonly EFContext _dbContext;
        private readonly IImagesManager _imagesManager;

        public CardsCommandService(EFContext dbContext, IImagesManager imagesManager)
        {
            _dbContext = dbContext;
            _imagesManager = imagesManager;
        }

        public async Task AddAsync(string deckName, string title, string question, string answer)
        {
            var deck = _dbContext.Decks.SingleAndEnsureExists(x => x.Name == deckName, ErrorCode.DeckDoesNotExist);
            deck.AddCard(new Card(title, question, answer));
            _dbContext.Decks.Update(deck);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(string deckName, List<Card> cards)
        {
            var deck = _dbContext.Decks.SingleAndEnsureExists(x => x.Name == deckName, ErrorCode.DeckDoesNotExist);
            cards.ForEach(card => deck.AddCard(card));
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
