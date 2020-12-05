using System;
using Flashcards.Core;
using Flashcards.Domain.Cards;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/decks/{deck}/cards")]
    public class CardsController : ApiController
    {
        public CardsController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpGet]
        public IActionResult Get(string deck)
            => Dispatch(new GetCardsByDeckQuery(deck));

        [HttpGet("{card}")]
        public IActionResult Get(string deck, Guid card)
            => Dispatch(new GetCardByIdQuery(card));

        [HttpPost]
        public IActionResult Post(string deck, [FromBody] AddCardCommand command) =>
            Dispatch(
                command.SetFromRoute(deck),
                result => new CardAddedEvent(Guid.Parse(result.Message)));

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
