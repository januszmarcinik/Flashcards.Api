using Flashcards.Core;

namespace Flashcards.Domain.Cards
{
    internal class EditCardCommandHandler : CommandHandlerBase<EditCardCommand>
    {
        private readonly ICardsRepository _cardsRepository;
        private readonly IImagesService _imagesService;

        public EditCardCommandHandler(ICardsRepository cardsRepository, IImagesService imagesService)
        {
            _cardsRepository = cardsRepository;
            _imagesService = imagesService;
        }

        public override Result Handle(EditCardCommand command)
        {
            var path = _imagesService.GetPhysicalPath(command.Deck, command.Id);

            command.Question = _imagesService.ProcessTextForEdit(command.Deck, command.Id, command.Question);
            command.Answer = _imagesService.ProcessTextForEdit(command.Deck, command.Id, command.Answer);

            _imagesService.RemoveDirectory(path);
            _imagesService.SaveImages(command.Deck, command.Id);

            var card = _cardsRepository.GetById(command.Id);
            if (card == null)
            {
                return Fail("Card with given ID does not exist.");
            }

            card.Question = command.Question;
            card.Answer = command.Answer;
            card.Confirmed = command.Confirmed;

            _cardsRepository.Update(card);

            return Result.Ok();
        }
    }
}
