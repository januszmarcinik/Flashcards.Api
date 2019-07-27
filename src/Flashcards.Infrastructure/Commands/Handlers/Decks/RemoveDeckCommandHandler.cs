using Flashcards.Core;
using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.Commands.Models.Decks;

namespace Flashcards.Infrastructure.Commands.Handlers.Decks
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
