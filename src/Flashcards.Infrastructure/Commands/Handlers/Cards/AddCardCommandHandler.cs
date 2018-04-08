using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Cards;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Commands.Handlers.Cards
{
    internal class AddCardCommandHandler : ICommandHandler<AddCardCommandModel>
    {
        private readonly ICardsCommandService _cardsCommandService;

        public AddCardCommandHandler(ICardsCommandService cardsCommandService)
        {
            _cardsCommandService = cardsCommandService;
        }

        public async Task HandleAsync(AddCardCommandModel command)
            => await _cardsCommandService.AddAsync(command.Deck, command.Title, command.Question, command.Answer);
    }
}
