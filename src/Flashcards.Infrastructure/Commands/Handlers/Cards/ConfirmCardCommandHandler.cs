using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Cards;
using Flashcards.Infrastructure.Services.Abstract.Commands;

namespace Flashcards.Infrastructure.Commands.Handlers.Cards
{
    public class ConfirmCardCommandHandler : ICommandHandler<ConfirmCardCommandModel>
    {
        private readonly ICardsCommandService _cardsCommandService;

        public ConfirmCardCommandHandler(ICardsCommandService cardsCommandService)
        {
            _cardsCommandService = cardsCommandService;
        }

        public async Task HandleAsync(ConfirmCardCommandModel command)
        {
            await _cardsCommandService.ConfirmAsync(command.Id);
        }
    }
}
