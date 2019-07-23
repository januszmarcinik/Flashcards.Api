using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Cards;
using Flashcards.Domain.Repositories;

namespace Flashcards.Infrastructure.Commands.Handlers.Cards
{
    internal class RemoveCardCommandHandler : ICommandHandler<RemoveCardCommandModel>
    {
        private readonly ICardsRepository _cardsRepository;

        public RemoveCardCommandHandler(ICardsRepository cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }

        public void Handle(RemoveCardCommandModel command)
            => _cardsRepository.Delete(command.Id);
    }
}
