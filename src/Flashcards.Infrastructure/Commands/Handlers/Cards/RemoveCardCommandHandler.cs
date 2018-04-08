using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Cards;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Commands.Handlers.Cards
{
    internal class RemoveCardCommandHandler : ICommandHandler<RemoveCardCommandModel>
    {
        private readonly ICardsCommandService _cardsCommandService;

        public RemoveCardCommandHandler(ICardsCommandService cardsCommandService)
        {
            _cardsCommandService = cardsCommandService;
        }

        public async Task HandleAsync(RemoveCardCommandModel command)
            => await _cardsCommandService.RemoveAsync(command.Id);
    }
}
