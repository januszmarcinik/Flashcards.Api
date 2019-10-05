using Flashcards.Core;

namespace Flashcards.Domain.Cards
{
    public class ConfirmCardCommandHandler : CommandHandlerBase<ConfirmCardCommand>
    {
        private readonly ICardsRepository _cardsRepository;

        public ConfirmCardCommandHandler(ICardsRepository cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }

        public override Result Handle(ConfirmCardCommand command)
        {
            var card = _cardsRepository.GetById(command.Id);
            if (card == null)
            {
                return Fail("Card with given ID does not exist.");
            }

            card.ToggleConfirmed();
            _cardsRepository.Update(card);

            return Result.Ok();
        }
    }
}
