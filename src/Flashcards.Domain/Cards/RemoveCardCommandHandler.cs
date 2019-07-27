using Flashcards.Core;

namespace Flashcards.Domain.Cards
{
    internal class RemoveCardCommandHandler : ICommandHandler<RemoveCardCommand>
    {
        private readonly ICardsRepository _cardsRepository;

        public RemoveCardCommandHandler(ICardsRepository cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }

        public Result Handle(RemoveCardCommand command)
        {
            _cardsRepository.Delete(command.Id);
            return Result.Ok();
        }
    }
}
