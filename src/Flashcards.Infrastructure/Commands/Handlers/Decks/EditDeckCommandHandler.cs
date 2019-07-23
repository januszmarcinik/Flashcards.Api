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

        public void Handle(EditDeckCommandModel command)
            => _decksRepository.Update(command.Id, command.Name, command.Description);
    }
}
