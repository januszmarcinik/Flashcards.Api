using System;
using Flashcards.Core;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Decks;

namespace Flashcards.Domain.Cards
{
    internal class AddCardCommandHandler : CommandHandlerBase<AddCardCommand>
    {
        private readonly ISqlCardsRepository _cardsRepository;
        private readonly IImagesService _imagesService;
        private readonly ISqlDecksRepository _decksRepository;

        public AddCardCommandHandler(ISqlCardsRepository cardsRepository, IImagesService imagesService, ISqlDecksRepository decksRepository)
        {
            _cardsRepository = cardsRepository;
            _imagesService = imagesService;
            _decksRepository = decksRepository;
        }

        public override Result Handle(AddCardCommand command)
        {
            if (command.Id.IsEmpty())
            {
                command.Id = Guid.NewGuid();
            }

            command.Question = _imagesService.ProcessTextForEdit(command.Deck, command.Id, command.Question);
            command.Answer = _imagesService.ProcessTextForEdit(command.Deck, command.Id, command.Answer);

            _imagesService.SaveImages(command.Deck, command.Id);

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
