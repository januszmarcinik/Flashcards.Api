using Flashcards.Core.Extensions;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Cards;
using System;
using Flashcards.Domain.Repositories;
using Flashcards.Domain.Services;

namespace Flashcards.Infrastructure.Commands.Handlers.Cards
{
    internal class AddCardCommandHandler : ICommandHandler<AddCardCommandModel>
    {
        private readonly ICardsRepository _cardsRepository;
        private readonly IImagesService _imagesService;

        public AddCardCommandHandler(ICardsRepository cardsRepository, IImagesService imagesService)
        {
            _cardsRepository = cardsRepository;
            _imagesService = imagesService;
        }

        public void Handle(AddCardCommandModel command)
        {
            if (command.Id.IsEmpty())
            {
                command.Id = Guid.NewGuid();
            }

            command.Question = _imagesService.ProcessTextForEdit(command.Topic, command.Category, command.Deck, command.Id, command.Question);
            command.Answer = _imagesService.ProcessTextForEdit(command.Topic, command.Category, command.Deck, command.Id, command.Answer);

            _imagesService.SaveImages(command.Topic, command.Category, command.Deck, command.Id);

            _cardsRepository.Add(command.Deck, command.Title, command.Question, command.Answer);
        }
    }
}
