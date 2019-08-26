using Flashcards.Core;

namespace Flashcards.Domain.Decks
{
    public class RemoveDeckCommandHandler : CommandHandlerBase<RemoveDeckCommand>
    {
        private readonly IDecksRepository _decksRepository;

        public RemoveDeckCommandHandler(IDecksRepository decksRepository)
        {
            _decksRepository = decksRepository;
        }

        public override Result Handle(RemoveDeckCommand command)
        {
            var deck = _decksRepository.GetById(command.Id);
            if (deck == null)
            {
                return Fail("Deck with given ID does not exist.");
            }

            _decksRepository.Delete(deck);

            return Result.Ok();
        }
    }
}
