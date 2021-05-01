using Flashcards.Application.Images;
using Flashcards.Core;

namespace Flashcards.Application.Cards
{
    internal class EditCardCommandHandler : CommandHandlerBase<EditCardCommand>
    {
        private readonly ISqlCardsRepository _cardsRepository;
        private readonly IImagesStorage _imagesStorage;
        private readonly ImagesProcessor _imagesProcessor;

        public EditCardCommandHandler(ISqlCardsRepository cardsRepository, IImagesStorage imagesStorage)
        {
            _cardsRepository = cardsRepository;
            _imagesStorage = imagesStorage;
            _imagesProcessor = new ImagesProcessor(_imagesStorage.VirtualPath);
        }

        public override Result Handle(EditCardCommand command)
        {
            command.Question = _imagesProcessor.ProcessTextForEdit(command.Deck, command.Id, command.Question);
            command.Answer = _imagesProcessor.ProcessTextForEdit(command.Deck, command.Id, command.Answer);

            _imagesStorage.RemoveImages(command.Deck, command.Id);
            _imagesStorage.SaveImages(command.Deck, command.Id, _imagesProcessor.ImagesData);

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
