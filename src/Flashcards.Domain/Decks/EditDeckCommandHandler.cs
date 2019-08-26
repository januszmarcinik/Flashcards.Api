using Flashcards.Core;

namespace Flashcards.Domain.Decks
{
    public class EditDeckCommandHandler : CommandHandlerBase<EditDeckCommand>
    {
        private readonly IDecksRepository _decksRepository;

        public EditDeckCommandHandler(IDecksRepository decksRepository)
        {
            _decksRepository = decksRepository;
        }

        public override Result Handle(EditDeckCommand command)
        {
            var deck = _decksRepository.GetById(command.Id);
            if (deck == null)
            {
                return Fail("Deck with given ID does not exist.");
            }

            var possibleDuplicate = _decksRepository.GetByName(command.Name);
            if (possibleDuplicate != null && possibleDuplicate.Id != deck.Id)
            {
                return Fail("Deck with given name already exist.");
            }

            deck.Name = command.Name;
            deck.Description = command.Description;
            _decksRepository.Update(deck);

            return Result.Ok();
        }
    }
}
