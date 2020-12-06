using System;
using System.Text.RegularExpressions;
using Flashcards.Core;
using Flashcards.Core.Extensions;

namespace Flashcards.Domain.Decks
{
    internal class AddDeckCommandHandler : CommandHandlerBase<AddDeckCommand>
    {
        private readonly ISqlDecksRepository _decksRepository;

        public AddDeckCommandHandler(ISqlDecksRepository decksRepository)
        {
            _decksRepository = decksRepository;
        }

        public override Result Handle(AddDeckCommand command)
        {
            var nameValidation = Regex.Match(command.Name, "([A-Za-z\\d\\-]+)");
            if (nameValidation.Success == false)
            {
                return Fail("Name can contains only letters from a-z and '-' not case sensitive.");
            }
            
            if (_decksRepository.GetByName(command.Name) != null)
            {
                return Fail("Deck with given name already exist.");
            }

            var id = command.Id.IsEmpty() ? Guid.NewGuid() : command.Id;

            var deck = new Deck(id, command.Name, command.Description);
            _decksRepository.Add(deck);

            return Result.Ok(deck.Id.ToString());
        }
    }
}
