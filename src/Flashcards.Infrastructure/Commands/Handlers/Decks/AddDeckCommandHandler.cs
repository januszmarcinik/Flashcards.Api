using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Decks;

namespace Flashcards.Infrastructure.Commands.Handlers.Decks
{
    internal class AddDeckCommandHandler : ICommandHandler<AddDeckCommandModel>
    {
        private readonly IDecksRepository _decksRepository;

        public AddDeckCommandHandler(IDecksRepository decksRepository)
        {
            _decksRepository = decksRepository;
        }

        public void Handle(AddDeckCommandModel command)
        {
            _decksRepository.Add(command.CategoryName, command.Name, command.Description);
        }
    }
}
