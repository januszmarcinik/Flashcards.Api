using Flashcards.Core;
using Flashcards.Domain.Repositories;
using Flashcards.Domain.Services;

namespace Flashcards.Domain.Cards
{
    internal class EditCardCommandHandler : ICommandHandler<EditCardCommand>
    {
        private readonly ICardsRepository _cardsRepository;
        private readonly IImagesService _imagesService;

        public EditCardCommandHandler(ICardsRepository cardsRepository, IImagesService imagesService)
        {
            _cardsRepository = cardsRepository;
            _imagesService = imagesService;
        }

        public Result Handle(EditCardCommand command)
        {
            var path = _imagesService.GetPhysicalPath(command.Topic, command.Category, command.Deck, command.Id);

            command.Question = _imagesService.ProcessTextForEdit(command.Topic, command.Category, command.Deck, command.Id, command.Question);
            command.Answer = _imagesService.ProcessTextForEdit(command.Topic, command.Category, command.Deck, command.Id, command.Answer);

            _imagesService.RemoveDirectory(path);
            _imagesService.SaveImages(command.Topic, command.Category, command.Deck, command.Id);

            _cardsRepository.Update(command.Id, command.Title, command.Question, command.Answer);

            return Result.Ok();
        }
    }
}
