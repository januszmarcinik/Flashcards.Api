using System;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Enums;
using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Cards;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/topics/{topic}/categories/{category}/decks/{deck}/cards")]
    public class CardsController : ApiController
    {
        private readonly ICardsRepository _cardsRepository;

        public CardsController(ICommandDispatcher commandDispatcher, ICardsRepository cardsRepository) 
            : base(commandDispatcher)
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
        public IActionResult Post(string topic, string category, string deck, [FromBody] AddCardCommandModel command)
            => Dispatch(command.SetFromRoute(topic.ToEnum<Topic>(), category, deck));

        [HttpPut]
        public IActionResult Put(string topic, string category, string deck, [FromBody] EditCardCommandModel command)
            => Dispatch(command.SetFromRoute(topic.ToEnum<Topic>(), category, deck, Guid.Parse(User.Identity.Name)));

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] ConfirmCardCommandModel command)
            => Dispatch(command);

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] RemoveCardCommandModel command)
            => Dispatch(command);
    }
}
