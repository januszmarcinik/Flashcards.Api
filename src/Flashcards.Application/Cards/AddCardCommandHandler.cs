using System;
using Flashcards.Application.Decks;
using Flashcards.Application.Images;
using Flashcards.Core;
using Flashcards.Core.Extensions;

namespace Flashcards.Application.Cards
{
    internal class AddCardCommandHandler : CommandHandlerBase<AddCardCommand>
    {
        private readonly ISqlCardsRepository _cardsRepository;
        private readonly IImagesStorage _imagesStorage;
        private readonly ISqlDecksRepository _decksRepository;
        private readonly ImagesProcessor _imagesProcessor;

        public AddCardCommandHandler(ISqlCardsRepository cardsRepository, IImagesStorage imagesStorage, ISqlDecksRepository decksRepository)
        {
            _cardsRepository = cardsRepository;
            _imagesStorage = imagesStorage;
            _decksRepository = decksRepository;
            _imagesProcessor = new ImagesProcessor(_imagesStorage.VirtualPath);
        }

        public override Result Handle(AddCardCommand command)
        {
            if (command.Id.IsEmpty())
            {
                command.Id = Guid.NewGuid();
            }

            command.Question = _imagesProcessor.ProcessTextForEdit(command.Deck, command.Id, command.Question);
            command.Answer = _imagesProcessor.ProcessTextForEdit(command.Deck, command.Id, command.Answer);

            _imagesStorage.SaveImages(command.Deck, command.Id, _imagesProcessor.ImagesData);

            var deck = _decksRepository.GetByName(command.Deck);
            if (deck == null)
            {
                return Fail("Deck with given ID does not exist.");
            }

            var card = new Card(deck.Id, command.Question, command.Answer);
            _cardsRepository.Add(card);

            return Result.Ok(card.Id.ToString());
        }
    }
}
