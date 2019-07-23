using Flashcards.Core.Extensions;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Cards;
using Flashcards.Infrastructure.Managers.Abstract;
using System;
using Flashcards.Domain.Repositories;

namespace Flashcards.Infrastructure.Commands.Handlers.Cards
{
    internal class AddCardCommandHandler : ICommandHandler<AddCardCommandModel>
    {
        private readonly ICardsRepository _cardsRepository;
        private readonly IImagesManager _imagesManager;

        public AddCardCommandHandler(ICardsRepository cardsRepository, IImagesManager imagesManager)
        {
            _cardsRepository = cardsRepository;
            _imagesManager = imagesManager;
        }

        public void Handle(AddCardCommandModel command)
        {
            if (command.Id.IsEmpty())
            {
                command.Id = Guid.NewGuid();
            }

            command.Question = _imagesManager.ProcessTextForEdit(command.Topic, command.Category, command.Deck, command.Id, command.Question);
            command.Answer = _imagesManager.ProcessTextForEdit(command.Topic, command.Category, command.Deck, command.Id, command.Answer);

            _imagesManager.SaveImages(command.Topic, command.Category, command.Deck, command.Id);

            _cardsRepository.Add(command.Deck, command.Title, command.Question, command.Answer);
        }
    }
}
