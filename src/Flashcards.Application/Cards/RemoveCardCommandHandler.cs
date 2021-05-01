using Flashcards.Core;

namespace Flashcards.Application.Cards
{
    internal class RemoveCardCommandHandler : CommandHandlerBase<RemoveCardCommand>
    {
        private readonly ISqlCardsRepository _cardsRepository;

        public RemoveCardCommandHandler(ISqlCardsRepository cardsRepository)
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
