using System;
using Flashcards.Core;
using Flashcards.Core.Extensions;

namespace Flashcards.Domain.Cards
{
    internal class AddCardCommandHandler : ICommandHandler<AddCardCommand>
    {
        private readonly ICardsRepository _cardsRepository;
        private readonly IImagesService _imagesService;

        public AddCardCommandHandler(ICardsRepository cardsRepository, IImagesService imagesService)
        {
            _cardsRepository = cardsRepository;
            _imagesService = imagesService;
        }

        public Result Handle(AddCardCommand command)
        {
            if (command.Id.IsEmpty())
            {
                command.Id = Guid.NewGuid();
            }

            command.Question = _imagesService.ProcessTextForEdit(command.Topic, command.Category, command.Deck, command.Id, command.Question);
            command.Answer = _imagesService.ProcessTextForEdit(command.Topic, command.Category, command.Deck, command.Id, command.Answer);

            _imagesService.SaveImages(command.Topic, command.Category, command.Deck, command.Id);

            _cardsRepository.Add(command.Deck, command.Title, command.Question, command.Answer);

            return Result.Ok();
        }
    }
}
