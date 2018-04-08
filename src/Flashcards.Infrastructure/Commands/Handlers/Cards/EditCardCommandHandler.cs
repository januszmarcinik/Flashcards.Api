using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Cards;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Commands.Handlers.Cards
{
    internal class EditCardCommandHandler : ICommandHandler<EditCardCommandModel>
    {
        private readonly ICardsCommandService _cardsCommandService;

        public EditCardCommandHandler(ICardsCommandService cardsCommandService)
        {
            _cardsCommandService = cardsCommandService;
        }

        public async Task HandleAsync(EditCardCommandModel command)
            => await _cardsCommandService.EditAsync(command.Id, command.Title, command.Question, command.Answer);
    }
}
