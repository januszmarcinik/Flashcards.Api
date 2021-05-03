using Flashcards.Application.Decks;
using Flashcards.Application.Images;
using Flashcards.Application.Metrics;
using Flashcards.Core;

namespace Flashcards.Application.Cards
{
    internal class AddCardCommandHandler : CommandHandlerBase<AddCardCommand>
    {
        private readonly ISqlCardsRepository _cardsRepository;
        private readonly IImagesStorage _imagesStorage;
        private readonly IMetricsService _metricsService;
        private readonly ISqlDecksRepository _decksRepository;
        private readonly ImagesProcessor _imagesProcessor;

        public AddCardCommandHandler(
            ISqlCardsRepository cardsRepository,
            IImagesStorage imagesStorage,
            IMetricsService metricsService,
            ISqlDecksRepository decksRepository)
        {
            _cardsRepository = cardsRepository;
            _imagesStorage = imagesStorage;
            _metricsService = metricsService;
            _decksRepository = decksRepository;
            _imagesProcessor = new ImagesProcessor(_imagesStorage.VirtualPath);
        }

        public override Result Handle(AddCardCommand command)
        {
            _metricsService.SaveTime(command.Id, "Storage", () =>
            {
                command.Question = _imagesProcessor.ProcessTextForEdit(command.Deck, command.Id, command.Question);
                command.Answer = _imagesProcessor.ProcessTextForEdit(command.Deck, command.Id, command.Answer);

                _imagesStorage.SaveImages(command.Deck, command.Id, _imagesProcessor.ImagesData);
            });

            Result result = null;
            _metricsService.SaveTime(command.Id, "SQL", () =>
            {
                var deck = _decksRepository.GetByName(command.Deck);
                if (deck == null)
                {
                    result = Fail("Deck with given ID does not exist.");
                    return;
                }

                var card = new Card(command.Id, deck.Id, command.Question, command.Answer);
                _cardsRepository.Add(card);
                
                result = Result.Ok(card.Id.ToString());
            });

            return result;
        }
    }
}
