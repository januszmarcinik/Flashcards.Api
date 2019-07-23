using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Cards;
using System.Threading.Tasks;
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

        public async Task HandleAsync(RemoveCardCommandModel command)
            => await _cardsRepository.RemoveAsync(command.Id);
    }
}
