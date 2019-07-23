using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Cards;

namespace Flashcards.Infrastructure.Commands.Handlers.Cards
{
    public class ConfirmCardCommandHandler : ICommandHandler<ConfirmCardCommandModel>
    {
        private readonly ICardsRepository _cardsRepository;

        public ConfirmCardCommandHandler(ICardsRepository cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }

        public void Handle(ConfirmCardCommandModel command)
        {
            _cardsRepository.Confirm(command.Id);
        }
    }
}
