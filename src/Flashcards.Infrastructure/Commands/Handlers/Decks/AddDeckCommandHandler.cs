using System.Threading.Tasks;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Decks;
using Flashcards.Infrastructure.Services.Abstract.Commands;

namespace Flashcards.Infrastructure.Commands.Handlers.Decks
{
    internal class AddDeckCommandHandler : ICommandHandler<AddDeckCommandModel>
    {
        private readonly IDeckCommandService _deckCommandService;

        public AddDeckCommandHandler(IDeckCommandService deckCommandService)
        {
            _deckCommandService = deckCommandService;
        }

        public async Task HandleAsync(AddDeckCommandModel command)
        {
            await _deckCommandService.CreateAsync(command.CategoryName, command.Name);
        }
    }
}
