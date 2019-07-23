using System.Threading.Tasks;
using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Decks;

namespace Flashcards.Infrastructure.Commands.Handlers.Decks
{
    public class EditDeckCommandHandler : ICommandHandler<EditDeckCommandModel>
    {
        private readonly IDecksRepository _decksRepository;

        public EditDeckCommandHandler(IDecksRepository decksRepository)
        {
            _decksRepository = decksRepository;
        }

        public async Task HandleAsync(EditDeckCommandModel command)
            => await _decksRepository.EditAsync(command.Id, command.Name, command.Description);
    }
}
