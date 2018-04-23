using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Decks;
using Flashcards.Infrastructure.Services.Abstract.Commands;

namespace Flashcards.Infrastructure.Commands.Handlers.Decks
{
    public class RemoveDeckCommandHandler : ICommandHandler<RemoveDeckCommandModel>
    {
        private readonly IDeckCommandService _deckCommandService;

        public RemoveDeckCommandHandler(IDeckCommandService deckCommandService)
        {
            _deckCommandService = deckCommandService;
        }

        public async Task HandleAsync(RemoveDeckCommandModel command)
            => await _deckCommandService.RemoveAsync(command.Id);
    }
}
