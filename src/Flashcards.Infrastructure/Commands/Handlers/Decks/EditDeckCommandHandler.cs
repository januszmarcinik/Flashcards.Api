using Flashcards.Core;
using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.Commands.Models.Decks;

namespace Flashcards.Infrastructure.Commands.Handlers.Decks
{
    public class EditDeckCommandHandler : ICommandHandler<EditDeckCommand>
    {
        private readonly IDecksRepository _decksRepository;

        public EditDeckCommandHandler(IDecksRepository decksRepository)
        {
            _decksRepository = decksRepository;
        }

        public Result Handle(EditDeckCommand command)
        {
            _decksRepository.Update(command.Id, command.Name, command.Description);
            return Result.Ok();
        }
    }
}
