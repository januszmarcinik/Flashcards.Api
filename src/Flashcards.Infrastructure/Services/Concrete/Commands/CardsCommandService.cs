using Flashcards.Core.Exceptions;
using Flashcards.Domain.Data.Abstract;
using Flashcards.Domain.Entities;
using Flashcards.Domain.Extensions;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Concrete.Commands
{
    internal class CardsCommandService : ICardsCommandService
    {
        private readonly IDbContext _dbContext;

        public CardsCommandService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(string deckName, string title, string question, string answer)
        {
            var deck = _dbContext.Decks.SingleAndEnsureExists(x => x.Name == deckName, ErrorCode.DeckDoesNotExist);
            deck.AddCard(new Card(title, question, answer));
            _dbContext.Decks.Update(deck);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Guid id, string title, string question, string answer)
        {
            var card = await _dbContext.Cards.FindAndEnsureExistsAsync(id, ErrorCode.CardDoesNotExist);
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
    }
}
