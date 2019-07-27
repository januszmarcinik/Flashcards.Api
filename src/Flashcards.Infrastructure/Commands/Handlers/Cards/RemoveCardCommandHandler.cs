using Flashcards.Core;
using Flashcards.Infrastructure.Commands.Models.Cards;
using Flashcards.Domain.Repositories;

namespace Flashcards.Infrastructure.Commands.Handlers.Cards
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
