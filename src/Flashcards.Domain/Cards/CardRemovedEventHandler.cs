using System;
using Flashcards.Core;

namespace Flashcards.Domain.Cards
{
    public class CardRemovedEventHandler : IEventHandler<CardRemovedEvent>
    {
        private readonly INoSqlCardsRepository _noSqlCardsRepository;

        public CardRemovedEventHandler(INoSqlCardsRepository noSqlCardsRepository)
        {
            _noSqlCardsRepository = noSqlCardsRepository;
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
        }
    }
}