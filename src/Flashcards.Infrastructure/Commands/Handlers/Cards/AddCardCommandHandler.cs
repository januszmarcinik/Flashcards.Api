using Flashcards.Core.Extensions;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Cards;
using Flashcards.Infrastructure.Managers.Abstract;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Commands.Handlers.Cards
{
    internal class AddCardCommandHandler : ICommandHandler<AddCardCommandModel>
    {
        private readonly ICardsCommandService _cardsCommandService;
        private readonly IImagesManager _imagesManager;

        public AddCardCommandHandler(ICardsCommandService cardsCommandService, IImagesManager imagesManager)
        {
            _cardsCommandService = cardsCommandService;
            _imagesManager = imagesManager;
        }

        public async Task HandleAsync(AddCardCommandModel command)
        {
            if (command.Id.IsEmpty())
            {
                command.Id = Guid.NewGuid();
            }

            command.Question = _imagesManager.ProcessTextForEdit(command.Topic, command.Category, command.Deck, command.Id, command.Question);
            command.Answer = _imagesManager.ProcessTextForEdit(command.Topic, command.Category, command.Deck, command.Id, command.Answer);

            _imagesManager.SaveImages(command.Topic, command.Category, command.Deck, command.Id);

            await _cardsCommandService.AddAsync(command.Deck, command.Title, command.Question, command.Answer);
        }
    }
}
