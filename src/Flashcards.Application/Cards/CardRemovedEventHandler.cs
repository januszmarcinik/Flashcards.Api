using System;
using System.Linq;
using Flashcards.Application.Decks;
using Flashcards.Core;

namespace Flashcards.Application.Cards
{
    public class CardRemovedEventHandler : IEventHandler<CardRemovedEvent>
    {
        private readonly INoSqlCardsRepository _noSqlCardsRepository;
        private readonly INoSqlDecksRepository _noSqlDecksRepository;

        public CardRemovedEventHandler(INoSqlCardsRepository noSqlCardsRepository, INoSqlDecksRepository noSqlDecksRepository)
        {
            _noSqlCardsRepository = noSqlCardsRepository;
            _noSqlDecksRepository = noSqlDecksRepository;
        }
        
        public void Handle(CardRemovedEvent @event)
        {
            var card = _noSqlCardsRepository.GetById(@event.CardId);
            if (card == null)
            {
                return;
            }

            if (card.PreviousCardId == Guid.Empty)
            {
                var next = _noSqlCardsRepository.GetById(card.NextCardId);
                next = next.Recreate(Guid.Empty, next.NextCardId);
                _noSqlCardsRepository.Update(next);
            }
            else if (card.NextCardId == Guid.Empty)
            {
                var previous = _noSqlCardsRepository.GetById(card.PreviousCardId);
                previous = previous.Recreate(previous.PreviousCardId, Guid.Empty);
                _noSqlCardsRepository.Update(previous);
            }
            else
            {
                var previous = _noSqlCardsRepository.GetById(card.PreviousCardId);
                var next = _noSqlCardsRepository.GetById(card.NextCardId);
                
                previous = previous.Recreate(previous.PreviousCardId, next.Id);
                next = next.Recreate(previous.Id, next.NextCardId);
                
                _noSqlCardsRepository.Update(previous);
                _noSqlCardsRepository.Update(next);
            }
            
            _noSqlCardsRepository.Remove(card.Id);
            UpdateDeck(card);
        }
        
        private void UpdateDeck(CardDto card)
        {
            var dto = _noSqlDecksRepository.GetByName(card.DeckName);
            var cards = dto.Cards.ToList();
            cards.RemoveAll(x => x.Id == card.Id);
            
            _noSqlDecksRepository.UpdateCards(dto.Id, cards);
        }
    }
}