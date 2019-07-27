using System;
using System.Collections.Generic;
using System.Linq;
using Flashcards.Core.Exceptions;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Cards;
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

        public CardDto GetById(Guid id)
        {
            var current = _dbContext.Cards.FindAndEnsureExists(id, ErrorCode.CardDoesNotExist);
            var ids = current.Deck.Cards
                .OrderBy(x => x.Title)
                .Select(x => x.Id)
                .ToList();

            var dto = current.ToDto(ids.NextOrDefault(current.Id), ids.PreviousOrDefault(current.Id));
            return dto;
        }

        public List<CardDto> GetByDeckName(string deckName)
        {
            var deck = _dbContext.Decks.SingleAndEnsureExists(x => x.Name == deckName, ErrorCode.DeckDoesNotExist);
            var cards = deck.Cards
                .OrderBy(x => x.Title)
                .Select(x => x.ToDto())
                .ToList();
            
            return cards;
        }

        public void Add(string deckName, string title, string question, string answer)
        {
            var deck = _dbContext.Decks.SingleAndEnsureExists(x => x.Name == deckName, ErrorCode.DeckDoesNotExist);
            deck.AddCard(new Card(title, question, answer));
            _dbContext.Decks.Update(deck);
            _dbContext.SaveChanges();
        }

        public void Update(Guid cardId, string title, string question, string answer)
        {
            var card = _dbContext.Cards.FindAndEnsureExists(cardId, ErrorCode.CardDoesNotExist);

            card.SetTitle(title);
            card.SetQuestion(question);
            card.SetAnswer(answer);

            _dbContext.Cards.Update(card);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var card = _dbContext.Cards.FindAndEnsureExists(id, ErrorCode.CardDoesNotExist);
            _dbContext.Cards.Remove(card);
            _dbContext.SaveChanges();
        }

        public void Confirm(Guid id)
        {
            var card = _dbContext.Cards.FindAndEnsureExists(id, ErrorCode.CardDoesNotExist);
            card.SetConfirmed(!card.Confirmed);
            _dbContext.Cards.Update(card);
            _dbContext.SaveChanges();
        }
    }
}
