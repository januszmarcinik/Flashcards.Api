using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Cards;
using Flashcards.Infrastructure.Managers.Abstract;
using System.Threading.Tasks;
using Flashcards.Domain.Repositories;

namespace Flashcards.Infrastructure.Commands.Handlers.Cards
{
    internal class EditCardCommandHandler : ICommandHandler<EditCardCommandModel>
    {
        private readonly ICardsRepository _cardsRepository;
        private readonly IImagesManager _imagesManager;

        public EditCardCommandHandler(ICardsRepository cardsRepository, IImagesManager imagesManager)
        {
            _cardsRepository = cardsRepository;
            _imagesManager = imagesManager;
        }

        public async Task HandleAsync(EditCardCommandModel command)
        {
            var path = _imagesManager.GetPhysicalPath(command.Topic, command.Category, command.Deck, command.Id);

            command.Question = _imagesManager.ProcessTextForEdit(command.Topic, command.Category, command.Deck, command.Id, command.Question);
            command.Answer = _imagesManager.ProcessTextForEdit(command.Topic, command.Category, command.Deck, command.Id, command.Answer);

            _imagesManager.RemoveDirectory(path);
            _imagesManager.SaveImages(command.Topic, command.Category, command.Deck, command.Id);

            await _cardsRepository.EditAsync(command.Id, command.Title, command.Question, command.Answer);
        }
    }
}
