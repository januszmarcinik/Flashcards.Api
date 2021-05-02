using System;
using Flashcards.Application.Cards;
using Flashcards.Application.Metrics;
using Flashcards.Core;
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
        public IActionResult Post(string deck, [FromBody] AddCardCommand command)
        {
            _metricsService.StartRequest(8);
            _metricsService.SaveCheckpoint("Request captured in CardsController");
            
            return Dispatch(
                command.SetFromRoute(deck),
                result => new CardAddedEvent(Guid.Parse(result.Message)));
        }

        [HttpPut]
        public IActionResult Put(string deck, [FromBody] EditCardCommand command) =>
            Dispatch(
                command.SetFromRoute(deck, Guid.Parse(User.Identity.Name)), 
                _ => new CardEditedEvent(command.Id));

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] RemoveCardCommand command)
            => Dispatch(
                command,
                _ => new CardRemovedEvent(command.Id));
    }
}
