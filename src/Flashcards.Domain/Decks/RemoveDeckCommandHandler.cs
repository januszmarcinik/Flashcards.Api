using Flashcards.Core;
using Flashcards.Domain.Repositories;

namespace Flashcards.Domain.Decks
{
    public class RemoveDeckCommandHandler : ICommandHandler<RemoveDeckCommand>
    {
        private readonly IDecksRepository _decksRepository;

        public RemoveDeckCommandHandler(IDecksRepository decksRepository)
        {
            _decksRepository = decksRepository;
        }

        public Result Handle(RemoveDeckCommand command)
        {
            _decksRepository.Delete(command.Id);
            return Result.Ok();
        }
    }
}
