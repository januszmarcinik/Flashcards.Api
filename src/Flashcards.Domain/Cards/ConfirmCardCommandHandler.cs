using Flashcards.Core;

namespace Flashcards.Domain.Cards
{
    public class ConfirmCardCommandHandler : ICommandHandler<ConfirmCardCommand>
    {
        private readonly ICardsRepository _cardsRepository;

        public ConfirmCardCommandHandler(ICardsRepository cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }

        public Result Handle(ConfirmCardCommand command)
        {
            _cardsRepository.Confirm(command.Id);
            return Result.Ok();
        }
    }
}
