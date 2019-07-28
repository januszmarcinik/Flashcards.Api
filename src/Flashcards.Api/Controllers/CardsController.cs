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
        private readonly ICardsRepository _cardsRepository;

        public CardsController(IMediator mediator, ICardsRepository cardsRepository) 
            : base(mediator)
        {
            _cardsRepository = cardsRepository;
        }

        [HttpGet]
        public IActionResult Get(string deck)
            => Ok(_cardsRepository.GetByDeckName(deck));

        [HttpGet("{card}")]
        public IActionResult Get(string deck, Guid card)
            => Ok(_cardsRepository.GetById(card));

        [HttpPost]
        public IActionResult Post(string deck, [FromBody] AddCardCommand command)
            => Dispatch(command.SetFromRoute(deck));

        [HttpPut]
        public IActionResult Put(string deck, [FromBody] EditCardCommand command)
            => Dispatch(command.SetFromRoute(deck, Guid.Parse(User.Identity.Name)));

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] ConfirmCardCommand command)
            => Dispatch(command);

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] RemoveCardCommand command)
            => Dispatch(command);
    }
}
