using System;
using Flashcards.Core;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Cards;
using Flashcards.Domain.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/topics/{topic}/categories/{category}/decks/{deck}/cards")]
    public class CardsController : ApiController
    {
        private readonly ICardsRepository _cardsRepository;

        public CardsController(IMediator mediator, ICardsRepository cardsRepository) 
            : base(mediator)
        {
            _cardsRepository = cardsRepository;
        }

        [HttpGet]
        public IActionResult Get(string topic, string category, string deck)
            => Ok(_cardsRepository.GetByDeckName(deck));

        [HttpGet("{card}")]
        public IActionResult Get(string topic, string category, string deck, Guid card)
            => Ok(_cardsRepository.GetById(card));

        [HttpPost]
        public IActionResult Post(string topic, string category, string deck, [FromBody] AddCardCommand command)
            => Dispatch(command.SetFromRoute(topic.ToEnum<Topic>(), category, deck));

        [HttpPut]
        public IActionResult Put(string topic, string category, string deck, [FromBody] EditCardCommand command)
            => Dispatch(command.SetFromRoute(topic.ToEnum<Topic>(), category, deck, Guid.Parse(User.Identity.Name)));

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] ConfirmCardCommand command)
            => Dispatch(command);

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] RemoveCardCommand command)
            => Dispatch(command);
    }
}
