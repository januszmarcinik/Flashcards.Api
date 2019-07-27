using Flashcards.Core;
using Flashcards.Domain.Repositories;

namespace Flashcards.Domain.Decks
{
    internal class AddDeckCommandHandler : ICommandHandler<AddDeckCommand>
    {
        private readonly IDecksRepository _decksRepository;

        public AddDeckCommandHandler(IDecksRepository decksRepository)
        {
            _decksRepository = decksRepository;
        }

        public Result Handle(AddDeckCommand command)
        {
            _decksRepository.Add(command.CategoryName, command.Name, command.Description);
            return Result.Ok();
        }
    }
}
