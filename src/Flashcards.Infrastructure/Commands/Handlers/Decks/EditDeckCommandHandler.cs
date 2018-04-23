using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Decks;
using Flashcards.Infrastructure.Services.Abstract.Commands;

namespace Flashcards.Infrastructure.Commands.Handlers.Decks
{
    public class EditDeckCommandHandler : ICommandHandler<EditDeckCommandModel>
    {
        private readonly IDeckCommandService _deckCommandService;

        public EditDeckCommandHandler(IDeckCommandService deckCommandService)
        {
            _deckCommandService = deckCommandService;
        }

        public async Task HandleAsync(EditDeckCommandModel command)
            => await _deckCommandService.EditAsync(command.Id, command.Name, command.Description);
    }
}
