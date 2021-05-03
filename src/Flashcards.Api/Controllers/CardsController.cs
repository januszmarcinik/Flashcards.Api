using System;
using System.Threading.Tasks;
using Flashcards.Application.Cards;
using Flashcards.Application.Metrics;
using Flashcards.Core;
using Flashcards.Core.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/decks/{deck}/cards")]
    public class CardsController : ApiController
    {
        private readonly IMetricsService _metricsService;
        private readonly INoSqlCardsRepository _cardsRepository;

        public CardsController(
            IMediator mediator, 
            IEventBus eventBus,
            IMetricsService metricsService,
            INoSqlCardsRepository cardsRepository) 
            : base(mediator, eventBus)
        {
            _metricsService = metricsService;
            _cardsRepository = cardsRepository;
        }

        [HttpGet("{card}")]
        public IActionResult Get(Guid card)
        {
            var result = _cardsRepository.GetById(card);
            if (result == null)
            {
                return NotFound("Card with given id does not exist.");
            }
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string deck, [FromBody] AddCardCommand command)
        {
            if (command.Id.IsEmpty())
            {
                command.Id = Guid.NewGuid();
            }
            
            _metricsService.StartRequest(command.Id);
            
            return await Dispatch(
                command.SetFromRoute(deck),
                result =>
                {
                    _metricsService.SetCheckpoint(command.Id);
                    return new CardAddedEvent(Guid.Parse(result.Message));
                });
        }

        [HttpPut]
        public async Task<IActionResult> Put(string deck, [FromBody] EditCardCommand command) =>
            await Dispatch(
                command.SetFromRoute(deck, Guid.Parse(User.Identity.Name)), 
                _ => new CardEditedEvent(command.Id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveCardCommand command)
            => await Dispatch(
                command,
                _ => new CardRemovedEvent(command.Id));
    }
}
