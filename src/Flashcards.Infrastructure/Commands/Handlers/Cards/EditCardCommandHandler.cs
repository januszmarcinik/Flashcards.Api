using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Cards;
using Flashcards.Infrastructure.Managers.Abstract;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Commands.Handlers.Cards
{
    internal class EditCardCommandHandler : ICommandHandler<EditCardCommandModel>
    {
        private readonly ICardsCommandService _cardsCommandService;
        private readonly IImagesManager _imagesManager;

        public EditCardCommandHandler(ICardsCommandService cardsCommandService, IImagesManager imagesManager)
        {
            _cardsCommandService = cardsCommandService;
            _imagesManager = imagesManager;
        }

        public async Task HandleAsync(EditCardCommandModel command)
        {
            var path = _imagesManager.GetPhysicalPath(command.Topic, command.Category, command.Deck, command.Id);

            command.Question = _imagesManager.ProcessTextForEdit(command.Topic, command.Category, command.Deck, command.Id, command.Question);
            command.Answer = _imagesManager.ProcessTextForEdit(command.Topic, command.Category, command.Deck, command.Id, command.Answer);

            _imagesManager.RemoveDirectory(path);
            _imagesManager.SaveImages(command.Topic, command.Category, command.Deck, command.Id);

            await _cardsCommandService.EditAsync(command.Id, command.Title, command.Question, command.Answer);
        }
    }
}
