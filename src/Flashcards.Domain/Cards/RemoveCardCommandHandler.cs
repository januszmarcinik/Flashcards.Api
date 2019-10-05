using Flashcards.Core;

namespace Flashcards.Domain.Cards
{
    internal class RemoveCardCommandHandler : CommandHandlerBase<RemoveCardCommand>
    {
        private readonly ICardsRepository _cardsRepository;

        public RemoveCardCommandHandler(ICardsRepository cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }

        public override Result Handle(RemoveCardCommand command)
        {
            var card = _cardsRepository.GetById(command.Id);
            if (card == null)
            {
                return Fail("Card with given ID does not exist.");
            }

            _cardsRepository.Delete(card);

            return Result.Ok();
        }
    }
}
