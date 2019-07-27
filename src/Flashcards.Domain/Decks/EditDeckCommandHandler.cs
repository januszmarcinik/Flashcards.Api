using Flashcards.Core;
using Flashcards.Domain.Repositories;

namespace Flashcards.Domain.Decks
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
