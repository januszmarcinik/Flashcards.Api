using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Decks;

namespace Flashcards.Infrastructure.Commands.Handlers.Decks
{
    public class RemoveDeckCommandHandler : ICommandHandler<RemoveDeckCommandModel>
    {
        private readonly IDecksRepository _decksRepository;

        public RemoveDeckCommandHandler(IDecksRepository decksRepository)
        {
            _decksRepository = decksRepository;
        }

        public void Handle(RemoveDeckCommandModel command)
            => _decksRepository.Delete(command.Id);
    }
}
