using System;
using Flashcards.Core;
using Flashcards.Core.Extensions;

namespace Flashcards.Domain.Decks
{
    internal class AddDeckCommandHandler : CommandHandlerBase<AddDeckCommand>
    {
        private readonly IDecksRepository _decksRepository;

        public AddDeckCommandHandler(IDecksRepository decksRepository)
        {
            _decksRepository = decksRepository;
        }

        public override Result Handle(AddDeckCommand command)
        {
            if (_decksRepository.GetByName(command.Name) != null)
            {
                return Fail("Deck with given name already exist.");
            }

            var id = command.Id.IsEmpty() ? Guid.NewGuid() : command.Id;

            var deck = new Deck(id, command.Name, command.Description);
            _decksRepository.Add(deck);

            return Result.Ok();
        }
    }
}
